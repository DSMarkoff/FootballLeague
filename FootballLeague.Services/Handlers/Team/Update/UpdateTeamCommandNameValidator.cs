using FootballLeague.Common.Validation;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Team.Update;
using System.Linq;

namespace FootballLeague.Services.Handlers.Team.Update
{
    public class UpdateTeamCommandNameValidator : IValidator<UpdateTeamCommand>
    {
        private const string NAME_ALREADY_EXISTS = "A team with such a name already exists.";

        private readonly AppDbContext dbContext;

        public UpdateTeamCommandNameValidator(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ValidationResult Validate(UpdateTeamCommand validated)
        {
            var isЕxisting = dbContext.Teams.Any(t => t.Name == validated.Name && t.Id != validated.Id);

            if (isЕxisting) return new ValidationResult(NAME_ALREADY_EXISTS);

            return new ValidationResult();
        }
    }
}
