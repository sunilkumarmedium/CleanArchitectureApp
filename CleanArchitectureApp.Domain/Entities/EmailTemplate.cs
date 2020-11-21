using System;

namespace CleanArchitectureApp.Domain.Entities
{
    public class EmailTemplate : AuditableBaseEntity
    {
         public virtual Guid EmailTemplateId { get; set; }

        public virtual int EmailTemplateInd { get; set; }

        public virtual string EmailTemplateName { get; set; }

        public virtual bool IsMasterTemplate { get; set; }

        public virtual bool EmailIsActive { get; set; }

        public virtual string EmailLabel { get; set; }

        public virtual string EmailSubject { get; set; }

        public virtual string EmailSenderEmail { get; set; }

        public virtual string EmailContent { get; set; }

        public virtual string EmailSignature { get; set; }
    }
}