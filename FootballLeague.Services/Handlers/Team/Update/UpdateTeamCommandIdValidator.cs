using FootballLeague.Common.Validation;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Team.Update;
using System.Linq;

namespace FootballLeague.Services.Handlers.Team.Update
{
    public class UpdateTeamCommandIdValidator : IValidator<UpdateTeamCommand>
    {
        private const string NONEXISTENT_TEAM = "A team with such an Id does not exist.";

        private readonly AppDbContext dbContext;

        public UpdateTeamCommandIdValidator(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ValidationResult Validate(UpdateTeamCommand validated)
        {
            var isЕxisting = dbContext.Teams.Any(t => t.Id == validated.Id);

            if (!isЕxisting) return new ValidationResult(NONEXISTENT_TEAM);

            return new ValidationResult();
        }
    }
}
