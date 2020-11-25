using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;

namespace CleanArchitectureApp.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(UserMap).Assembly.ExportedTypes);

            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var NHConfiguration = new Configuration();
            if (configuration.GetValue<string>("DBProvider").ToLower().Equals("mssql"))
            {
                NHConfiguration.DataBaseIntegration(c =>
                {
                    c.Dialect<MsSql2008Dialect>();
                    c.ConnectionString = configuration.GetConnectionString("MSSQLConnection");
                    c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    c.LogFormattedSql = true;
                    c.LogSqlInConsole = true;
                });
            }
            else if (configuration.GetValue<string>("DBProvider").ToLower().Equals("postgres"))
            {
                NHConfiguration.DataBaseIntegration(c =>
                {
                    c.Dialect<PostgreSQL82Dialect>();
                    c.ConnectionString = configuration.GetConnectionString("PostgresConnection");
                    c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    c.LogFormattedSql = true;
                    c.LogSqlInConsole = true;
                });
            }
            NHConfiguration.AddMapping(domainMapping);

            var sessionFactory = NHConfiguration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());

            #region Repositories

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddTransient<IUserStatusRepositoryAsync, UserStatusRepositoryAsync>();
            services.AddTransient<ILoginLogRepositoryAsync, LoginLogRepositoryAsync>();
            services.AddTransient<ILoginLogTypeRepositoryAsync, LoginLogTypeRepositoryAsync>();
            services.AddTransient<IUserTokenRepositoryAsync, UserTokenRepositoryAsync>();
            services.AddTransient<IEmailTemplateRepositoryAsync, EmailTemplateRepositoryAsync>();
            services.AddTransient<IEmailRecipientRepositoryAsync, EmailRecipientRepositoryAsync>();

            #endregion Repositories
        }
    }
}