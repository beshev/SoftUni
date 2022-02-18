using System.ComponentModel.DataAnnotations;

namespace Git.ViewModels.Commits
{
    public class RepositoryCommitInputModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CreatorId { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
