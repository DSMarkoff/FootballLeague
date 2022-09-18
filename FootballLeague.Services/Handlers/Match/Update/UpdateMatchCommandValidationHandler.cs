using FootballLeague.Common.Validation;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Match.Update;
using FootballLeague.Services.Results.Match.Update;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Update
{
    public class UpdateMatchCommandValidationHandler : ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult>
    {
        private readonly ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult> decoratee;
        private readonly IValidator<UpdateMatchCommand> validator;

        public UpdateMatchCommandValidationHandler(
            ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult> decoratee,
            IValidator<UpdateMatchCommand> validator)
        {
            this.decoratee = decoratee;
            this.validator = validator;
        }

        public async Task<UpdateMatchResult> Handle(UpdateMatchCommand command)
        {
            var result = validator.Validate(command);

            if (!result.IsSuccessful) return new UpdateMatchResult(result.ErrorMessage);

            return await decoratee.Handle(command);
        }
    }
}
