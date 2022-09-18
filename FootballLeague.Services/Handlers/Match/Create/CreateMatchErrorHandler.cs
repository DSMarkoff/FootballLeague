using FootballLeague.Common.Logging;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Match.Create;
using FootballLeague.Services.Results.Match.Create;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Create
{
    public class CreateMatchErrorHandler : ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> decoratee;

        public CreateMatchErrorHandler(ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<CreateMatchResult> Handle(CreateMatchCommand command)
        {
            try
            {
                return await decoratee.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.Log($"C/Q: {nameof(CreateMatchCommand)}, AT {DateTime.UtcNow}, {ex}");

                return new CreateMatchResult(GENERAL_ERROR);
            }
        }
    }
}

