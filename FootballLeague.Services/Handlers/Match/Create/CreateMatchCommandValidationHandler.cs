using FootballLeague.Common.Validation;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Match.Create;
using FootballLeague.Services.Results.Match.Create;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Create
{
    public class CreateMatchCommandValidationHandler : ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>
    {
        private readonly ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> decoratee;
        private readonly IValidator<CreateMatchCommand> validator;

        public CreateMatchCommandValidationHandler(
            ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> decoratee,
            IValidator<CreateMatchCommand> validator)
        {
            this.decoratee = decoratee;
            this.validator = validator;
        }

        public async Task<CreateMatchResult> Handle(CreateMatchCommand command)
        {
            var result = validator.Validate(command);

            if (!result.IsSuccessful) return new CreateMatchResult(result.ErrorMessage);

            return await decoratee.Handle(command);
        }
    }
}
