using FootballLeague.Common.Logging;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Team.Update;
using FootballLeague.Services.Results.Team.Update;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Update
{
    public class UpdateTeamErrorHandler : ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult> decoratee;

        public UpdateTeamErrorHandler(ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<UpdateTeamResult> Handle(UpdateTeamCommand command)
        {
            try
            {
                return await decoratee.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.Log($"C/Q: {nameof(UpdateTeamCommand)}, AT {DateTime.UtcNow}, {ex}");

                return new UpdateTeamResult(GENERAL_ERROR);
            }
        }
    }
}
