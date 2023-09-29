using System.ComponentModel.DataAnnotations;

namespace AccountingApp.Application.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}