using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Match.Delete;
using FootballLeague.Services.Results.Match.Delete;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Delete
{
    public class DeleteMatchCommandValidationHandler : ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult>
    {
        private const string NONEXISTENT_MATCH = "A match with such an Id does not exist.";

        private readonly ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult> decoratee;
        private readonly AppDbContext dbContext;

        public DeleteMatchCommandValidationHandler(
            ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult> decoratee,
            AppDbContext dbContext)
        {
            this.decoratee = decoratee;
            this.dbContext = dbContext;
        }

        public async Task<DeleteMatchResult> Handle(DeleteMatchCommand command)
        {
            var isЕxisting = dbContext.Matches.Any(m => m.Id == command.Id);

            if (!isЕxisting) return new DeleteMatchResult(NONEXISTENT_MATCH);

            return await decoratee.Handle(command);
        }
    }
}
