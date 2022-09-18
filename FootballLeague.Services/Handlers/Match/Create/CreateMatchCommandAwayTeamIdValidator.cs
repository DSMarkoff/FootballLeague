using FootballLeague.Common.Validation;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Match.Create;
using System.Linq;

namespace FootballLeague.Services.Handlers.Match.Create
{
    public class CreateMatchCommandAwayTeamIdValidator : IValidator<CreateMatchCommand>
    {
        private const string NONEXISTENT_AWAY_TEAM = "Away team does not exist.";

        private readonly AppDbContext dbContext;

        public CreateMatchCommandAwayTeamIdValidator(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ValidationResult Validate(CreateMatchCommand validated)
        {
            var isЕxisting = dbContext.Teams.Any(t => t.Id == validated.AwayTeamId);

            if (!isЕxisting) return new ValidationResult(NONEXISTENT_AWAY_TEAM);

            return new ValidationResult();
        }
    }
}
