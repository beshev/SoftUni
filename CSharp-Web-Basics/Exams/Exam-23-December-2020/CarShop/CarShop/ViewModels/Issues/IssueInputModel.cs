using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels.Issues
{
    public class IssueInputModel
    {
        public string CarId { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }
    }
}
