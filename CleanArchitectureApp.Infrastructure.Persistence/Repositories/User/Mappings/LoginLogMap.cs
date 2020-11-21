using CleanArchitectureApp.Domain;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public partial class LoginLogMap : ClassMapping<LoginLog>
    {
        public LoginLogMap()
        {
            Schema("dbo");
            Table("LoginLogs");
            Lazy(true);
            Id(x => x.LoginLogId, map => map.Generator(Generators.Guid));
            //Property(x => x.LoginLogInd, map => { map.NotNullable(true); map.Precision(19); });
            Property(x => x.LoginDate);
            Property(x => x.LoginUserIP, map => map.Length(50));
            Property(x => x.LoginSuccess);
            Property(x => x.UserIdentifier, map => map.Length(50));
            ManyToOne(x => x.LoginLogTypes, map =>
            {
                map.Column("LoginLogTypeId");
                map.NotNullable(true);
                map.Cascade(Cascade.None);
            });
        }
    }
}