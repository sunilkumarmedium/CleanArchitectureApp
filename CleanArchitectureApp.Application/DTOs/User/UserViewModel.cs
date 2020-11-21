using System;

namespace CleanArchitectureApp.Application.DTOs.User
{
    public class UserViewModel
    {
        public virtual Guid UserId { get; set; }
        public virtual string UserStatus { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserEmail { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}