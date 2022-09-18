using FootballLeague.Common.Validation;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Match.Update;
using System.Linq;

namespace FootballLeague.Services.Handlers.Match.Update
{
    public class UpdateMatchCommandEndValidator : IValidator<UpdateMatchCommand>
    {
        private const string END_BEFORE_START = "The end of the game can not be before the start.";

        private readonly AppDbContext dbContext;

        public UpdateMatchCommandEndValidator(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ValidationResult Validate(UpdateMatchCommand validated)
        {
            var matchStart = dbContext.Matches
                                .Where(m => m.Id == validated.Id)
                                .Select(m => m.Start)
                                .FirstOrDefault();
            var matchEnd = validated.End;

            if (matchStart > matchEnd) return new ValidationResult(END_BEFORE_START);

            return new ValidationResult();
        }
    }
}
