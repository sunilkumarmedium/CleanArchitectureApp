using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Domain;
using NHibernate;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public class LoginLogRepositoryAsync: GenericRepositoryAsync<LoginLog>, ILoginLogRepositoryAsync
    {
        public LoginLogRepositoryAsync(ISession session) : base(session)
        { }
    }
}