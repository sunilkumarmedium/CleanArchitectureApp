using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Domain.Entities;
using NHibernate;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public class EmailTemplateRepositoryAsync : GenericRepositoryAsync<EmailTemplate>, IEmailTemplateRepositoryAsync
    {
        public EmailTemplateRepositoryAsync(ISession session) : base(session)
        {
        }
    }
}