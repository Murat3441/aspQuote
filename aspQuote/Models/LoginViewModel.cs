using System.ComponentModel.DataAnnotations;

namespace aspQuote.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required field.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
