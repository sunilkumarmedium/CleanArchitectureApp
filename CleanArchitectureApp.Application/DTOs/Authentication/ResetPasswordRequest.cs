using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureApp.Application.DTOs.Authentication
{
    public class ResetPasswordRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}