using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Domain.Entities;
using NHibernate;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public class EmailRecipientRepositoryAsync : GenericRepositoryAsync<EmailRecipient>, IEmailRecipientRepositoryAsync
    {
        public EmailRecipientRepositoryAsync(ISession session) : base(session)
        {
        }
    }
}