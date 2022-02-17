using System.ComponentModel.DataAnnotations;

namespace CarShop.Services.Validators
{
    public interface IValidatorsService
    {
        public IEnumerable<ValidationResult> IsValid(object model);
    }
}
