namespace FootballManager.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class UserRegisterInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(60)]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
