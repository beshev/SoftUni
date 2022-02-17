using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels.Users
{
    public class UserRegisterInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }
        
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
    }
}
