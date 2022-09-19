using FootballLeague.Common.Logging;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Match.Delete;
using FootballLeague.Services.Results.Match.Delete;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Delete
{
    public class DeleteMatchErrorHandler : ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult> decoratee;

        public DeleteMatchErrorHandler(ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<DeleteMatchResult> Handle(DeleteMatchCommand command)
        {
            try
            {
                return await decoratee.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.Log($"C/Q: {nameof(DeleteMatchCommand)}, AT {DateTime.UtcNow}, {ex}");

                return new DeleteMatchResult(GENERAL_ERROR);
            }
        }
    }
}
