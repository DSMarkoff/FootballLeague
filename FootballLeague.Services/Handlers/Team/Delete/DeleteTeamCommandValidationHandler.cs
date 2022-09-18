using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Team.Delete;
using FootballLeague.Services.Results.Team.Delete;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Delete
{
    public class DeleteTeamCommandValidationHandler : ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult>
    {
        private const string NONEXISTENT_TEAM = "A team with such an Id does not exist.";

        private readonly ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult> decoratee;
        private readonly AppDbContext dbContext;

        public DeleteTeamCommandValidationHandler(
            ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult> decoratee,
            AppDbContext dbContext)
        {
            this.decoratee = decoratee;
            this.dbContext = dbContext;
        }

        public async Task<DeleteTeamResult> Handle(DeleteTeamCommand command)
        {
            var isЕxisting = dbContext.Teams.Any(t => t.Id == command.Id);

            if (!isЕxisting) return new DeleteTeamResult(NONEXISTENT_TEAM);

            return await decoratee.Handle(command);
        }
    }
}
