using System.ComponentModel.DataAnnotations;

namespace ResumeMaker.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
