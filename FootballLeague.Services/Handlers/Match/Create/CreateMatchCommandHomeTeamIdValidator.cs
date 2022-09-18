using FootballLeague.Common.Validation;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Match.Create;
using System.Linq;

namespace FootballLeague.Services.Handlers.Match.Create
{
    public class CreateMatchCommandHomeTeamIdValidator : IValidator<CreateMatchCommand>
    {
        private const string NONEXISTENT_HOME_TEAM = "Home team does not exist.";

        private readonly AppDbContext dbContext;

        public CreateMatchCommandHomeTeamIdValidator(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ValidationResult Validate(CreateMatchCommand validated)
        {
            var isЕxisting = dbContext.Teams.Any(t => t.Id == validated.HomeTeamId);

            if (!isЕxisting) return new ValidationResult(NONEXISTENT_HOME_TEAM);

            return new ValidationResult();
        }
    }
}
