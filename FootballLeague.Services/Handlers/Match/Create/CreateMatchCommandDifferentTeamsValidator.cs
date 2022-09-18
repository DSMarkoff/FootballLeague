using FootballLeague.Common.Validation;
using FootballLeague.Services.Commands.Match.Create;

namespace FootballLeague.Services.Handlers.Match.Create
{
    public class CreateMatchCommandDifferentTeamsValidator : IValidator<CreateMatchCommand>
    {
        private const string DIFFERENT_TEAMS = "Home team must be different from away team";

        public ValidationResult Validate(CreateMatchCommand validated)
        {
            if (validated.HomeTeamId == validated.AwayTeamId) return new ValidationResult(DIFFERENT_TEAMS);

            return new ValidationResult();
        }
    }
}
