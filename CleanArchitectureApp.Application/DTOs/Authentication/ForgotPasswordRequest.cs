using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureApp.Application.DTOs.Authentication
{
    public class ForgotPasswordRequest
    {
        [Required]
        public string UserName { get; set; }
    }
}