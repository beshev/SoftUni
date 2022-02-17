using System.ComponentModel.DataAnnotations;

namespace CarShop.Services.Validators
{
    public class ValidatorsService : IValidatorsService
    {
        public IEnumerable<ValidationResult> IsValid(object model)
        {
            var context = new ValidationContext(model);
            var errorsList = new List<ValidationResult>();

            Validator.TryValidateObject(model, context, errorsList, true);

            return errorsList;
        }
    }
}
