using FootballLeague.Common.Validation;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Match.Update;
using System.Linq;

namespace FootballLeague.Services.Handlers.Match.Update
{
    public class UpdateMatchCommandIdValidator : IValidator<UpdateMatchCommand>
    {
        private const string NONEXISTENT_MATCH = "A match with such an Id does not exist.";

        private readonly AppDbContext dbContext;

        public UpdateMatchCommandIdValidator(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ValidationResult Validate(UpdateMatchCommand validated)
        {
            var isЕxisting = dbContext.Matches.Any(m => m.Id == validated.Id);

            if (!isЕxisting) return new ValidationResult(NONEXISTENT_MATCH);

            return new ValidationResult();
        }
    }
}
