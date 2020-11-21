using System;

namespace CleanArchitectureApp.Domain
{
    public abstract class AuditableBaseEntity
    {
        public virtual Guid CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual Guid UpdatedBy { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
    }
}