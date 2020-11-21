using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureApp.Application.DTOs.Authentication
{
    public class AuthenticationRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}