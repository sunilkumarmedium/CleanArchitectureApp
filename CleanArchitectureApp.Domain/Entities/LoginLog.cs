using System;

namespace CleanArchitectureApp.Domain
{
    public partial class LoginLog
    {
        public virtual Guid LoginLogId { get; set; }
        public virtual LoginLogType LoginLogTypes { get; set; }
        public virtual long LoginLogInd { get; set; }
        public virtual DateTime? LoginDate { get; set; }
        public virtual string LoginUserIP { get; set; }
        public virtual bool? LoginSuccess { get; set; }
        public virtual string UserIdentifier { get; set; }
    }
}