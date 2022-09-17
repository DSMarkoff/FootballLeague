using FootballLeague.Abstraction.Handlers;
using FootballLeague.Services.Commands.Team.Create;
using FootballLeague.Services.Logging;
using FootballLeague.Services.Results.Team.Create;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Create
{
    public class CreateTeamErrorHandler : ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> decoratee;

        public CreateTeamErrorHandler(ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<CreateTeamResult> Handle(CreateTeamCommand command)
        {
            try
            {
                return await decoratee.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.Log($"{DateTime.UtcNow}, {ex}");

                return new CreateTeamResult(GENERAL_ERROR);
            }
        }
    }
}
