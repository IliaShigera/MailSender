using System.ComponentModel.DataAnnotations;

namespace MailSender.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not equals")]       
        [Display(Name = "Comfirm password")]
        public string PasswordConfirm { get; set; }
    }
}
