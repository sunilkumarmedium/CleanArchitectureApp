using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Domain;
using NHibernate;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public class LoginLogTypeRepositoryAsync : GenericRepositoryAsync<LoginLogType>, ILoginLogTypeRepositoryAsync
    {
        public LoginLogTypeRepositoryAsync(ISession session) : base(session)
        { }
    }
}