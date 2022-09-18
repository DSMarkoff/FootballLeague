using System.Collections.Generic;

namespace FootballLeague.Common.Validation
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T validated);
    }

    public class CompositeValidator<T> : IValidator<T>
    {
        private readonly IEnumerable<IValidator<T>> validators;

        public CompositeValidator(IEnumerable<IValidator<T>> validators)
        {
            this.validators = validators;
        }

        public ValidationResult Validate(T model)
        {
            foreach (var validator in validators)
            {
                var result = validator.Validate(model);

                if (!result.IsSuccessful) return result;
            }

            return new ValidationResult();
        }
    }
}
