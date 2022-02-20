namespace FootballManager.ViewModels.Players
{
    using System.ComponentModel.DataAnnotations;

    public class PlayerInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Position { get; set; }

        [Range(0, 10)]
        public byte Speed { get; set; }

        [Range(0, 10)]
        public byte Endurance { get; set; }
    }
}
