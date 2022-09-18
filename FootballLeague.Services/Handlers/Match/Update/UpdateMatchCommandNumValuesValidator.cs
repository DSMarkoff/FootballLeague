using FootballLeague.Common.Validation;
using FootballLeague.Services.Commands.Match.Update;

namespace FootballLeague.Services.Handlers.Match.Update
{
    public class UpdateMatchCommandNumValuesValidator : IValidator<UpdateMatchCommand>
    {
        private const string NUMERICAL_VALUES_LESS_THAN_ZERO = "All numeric values must be equal or greater than 0.";
        public ValidationResult Validate(UpdateMatchCommand validated)
        {
            if (validated.HomeTeamGoals < 0 || validated.AwayTeamGoals < 0)
                return new ValidationResult(NUMERICAL_VALUES_LESS_THAN_ZERO);

            return new ValidationResult();
        }
    }
}
