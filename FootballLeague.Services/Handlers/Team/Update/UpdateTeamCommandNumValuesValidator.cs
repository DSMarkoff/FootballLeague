using FootballLeague.Common.Validation;
using FootballLeague.Services.Commands.Team.Update;

namespace FootballLeague.Services.Handlers.Team.Update
{
    public class UpdateTeamCommandNumValuesValidator : IValidator<UpdateTeamCommand>
    {
        private const string NUMERICAL_VALUES_LESS_THAN_ZERO = "All numeric values must be equal or greater than 0.";
        public ValidationResult Validate(UpdateTeamCommand validated)
        {
            if (validated.Won < 0 || 
                validated.Drawn < 0 || 
                validated.Lost < 0 || 
                validated.GoalsFor < 0 || 
                validated.GoalsAgainst < 0) 
                    return new ValidationResult(NUMERICAL_VALUES_LESS_THAN_ZERO);

            return new ValidationResult();
        }
    }
}
