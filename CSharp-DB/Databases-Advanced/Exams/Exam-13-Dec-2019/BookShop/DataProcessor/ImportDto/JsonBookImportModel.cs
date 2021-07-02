using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class JsonBookImportModel
    {
        [Required]
        public int? Id { get; set; }
    }

}
