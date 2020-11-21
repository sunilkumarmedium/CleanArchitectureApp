namespace CleanArchitectureApp.Domain
{
    public class UserStatuses
    {
        public virtual int UserStatusId { get; set; }
        public virtual string StatusDescription { get; set; }
        public virtual string StatusValue { get; set; }
    }
}