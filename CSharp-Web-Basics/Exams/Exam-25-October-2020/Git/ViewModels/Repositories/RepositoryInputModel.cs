using System.ComponentModel.DataAnnotations;

namespace Git.ViewModels.Repositories
{
    public class RepositoryInputModel
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string RepositoryType { get; set; }
    }
}
