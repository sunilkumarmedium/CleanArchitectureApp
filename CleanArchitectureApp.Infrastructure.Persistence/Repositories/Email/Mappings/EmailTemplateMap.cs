using System;
using CleanArchitectureApp.Domain.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public class EmailTemplateMap : ClassMapping<EmailTemplate>
    {
        public EmailTemplateMap()
        {
            Table("EmailTemplates");

            Id(x => x.EmailTemplateId, map =>
            {
                map.Generator(Generators.Guid);
                map.Type(NHibernateUtil.Guid);
                map.UnsavedValue(Guid.Empty);
            });

            Property(x => x.EmailTemplateInd, map =>
            {
                map.Type(NHibernateUtil.Int32);
                map.NotNullable(true);
            });

            Property(x => x.EmailTemplateName, map =>
            {
                map.Length(200);
                map.Type(NHibernateUtil.String);
                map.NotNullable(true);
            });

            Property(x => x.EmailLabel, map =>
            {
                map.Length(50);
                map.Type(NHibernateUtil.String);
                map.NotNullable(true);
            });

            Property(x => x.EmailSubject, map =>
            {
                map.Length(500);
                map.Type(NHibernateUtil.String);
                map.NotNullable(true);
            });
            Property(x => x.EmailSenderEmail, map =>
            {
                map.Length(50);
                map.Type(NHibernateUtil.String);
                map.NotNullable(true);
            });

            Property(x => x.EmailContent, map =>
            {
                map.Type(NHibernateUtil.StringClob);
                map.NotNullable(true);
            });

            Property(x => x.EmailSignature, map =>
            {
                map.Length(500);
                map.Type(NHibernateUtil.StringClob);
                map.NotNullable(true);
            });
            Property(x => x.IsMasterTemplate, map =>
            {
                map.Type(NHibernateUtil.Boolean);
                map.NotNullable(true);
            });

            Property(x => x.EmailIsActive, map =>
            {
                map.Type(NHibernateUtil.Boolean);
                map.NotNullable(true);
            });

            Property(x => x.CreatedDate, map =>
            {
                map.Column("CreatedDate");
                map.NotNullable(true);
            });

            Property(x => x.UpdatedDate, map =>
            {
                map.Column("UpdatedDate");
                map.NotNullable(false);
            });

            Property(x => x.CreatedBy, map =>
            {
                map.Column("CreatedBy");
                map.Type(NHibernateUtil.Guid);
                map.NotNullable(true);
            });

            Property(x => x.UpdatedBy, map =>
            {
                map.Column("UpdatedBy");
                map.Type(NHibernateUtil.Guid);
                map.NotNullable(false);
            });
        }
    }
}
