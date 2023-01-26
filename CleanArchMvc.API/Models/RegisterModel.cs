using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.API.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; } = null!;



        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [DataType(DataType.Password)]
        [Display(Name = "Confirm passworkd")]
        [Compare("Password", ErrorMessage = "Password don't match!")]
        public string ConfirmPassword { get; set; } = null!;
    }
}