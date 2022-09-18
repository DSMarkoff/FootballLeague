using FootballLeague.Common.Logging;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Match.Update;
using FootballLeague.Services.Results.Match.Update;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Update
{
    public class UpdateMatchErrorHandler : ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult> decoratee;

        public UpdateMatchErrorHandler(ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<UpdateMatchResult> Handle(UpdateMatchCommand command)
        {
            try
            {
                return await decoratee.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.Log($"C/Q: {nameof(UpdateMatchCommand)}, AT {DateTime.UtcNow}, {ex}");

                return new UpdateMatchResult(GENERAL_ERROR);
            }
        }
    }
}

