using FootballLeague.Abstraction.Handlers;
using FootballLeague.Common.Logging;
using FootballLeague.Services.Commands.Team.Delete;
using FootballLeague.Services.Results.Team.Delete;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Delete
{
    public class DeleteTeamErrorHandler : ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult> decoratee;

        public DeleteTeamErrorHandler(ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<DeleteTeamResult> Handle(DeleteTeamCommand command)
        {
            try
            {
                return await decoratee.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.Log($"C/Q: {nameof(DeleteTeamCommand)}, AT {DateTime.UtcNow}, {ex}");

                return new DeleteTeamResult(GENERAL_ERROR);
            }
        }
    }
}
