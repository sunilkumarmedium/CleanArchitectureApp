using CleanArchitectureApp.Application.Interfaces.Repositories;
using NHibernate;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<Domain.User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(ISession session) : base(session)
        { }
    }
}