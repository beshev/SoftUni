using System.ComponentModel.DataAnnotations;

namespace Git.Services.Validators
{
    public interface IValidatorsService
    {
        public IEnumerable<ValidationResult> IsValid(object model);
    }
}
