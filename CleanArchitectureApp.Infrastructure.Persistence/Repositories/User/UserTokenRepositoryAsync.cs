using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Domain;
using NHibernate;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public class UserTokenRepositoryAsync : GenericRepositoryAsync<UserToken>, IUserTokenRepositoryAsync
    {
        public UserTokenRepositoryAsync(ISession session) : base(session)
        {
        }
    }
}