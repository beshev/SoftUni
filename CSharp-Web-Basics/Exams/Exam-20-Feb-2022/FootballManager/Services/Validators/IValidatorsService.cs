namespace FootballManager.Services.Validators
{
    using System.ComponentModel.DataAnnotations;

    public interface IValidatorsService
    {
        public IEnumerable<ValidationResult> IsValid(object model);
    }
}
