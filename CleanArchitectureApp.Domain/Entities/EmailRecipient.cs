using System;

namespace CleanArchitectureApp.Domain.Entities
{
    public class EmailRecipient : AuditableBaseEntity
    {
         public virtual Guid EmailRecipientId { get; set; }

        public virtual Guid EmailTemplateID { get; set; }

        public virtual string RecipientEmail { get; set; }

        public virtual DateTime ToBeProcessedOn { get; set; }

        public virtual DateTime EmailSentOn { get; set; }

        public virtual string EmailLabel { get; set; }

        public virtual string EmailSubject { get; set; }

        public virtual string EmailSenderEmail { get; set; }

        public virtual string EmailContent { get; set; }

        public virtual string EmailSignature { get; set; }

        public virtual bool IsPending { get; set; }

        public virtual Guid RecipientUserID { get; set; }
    }
}