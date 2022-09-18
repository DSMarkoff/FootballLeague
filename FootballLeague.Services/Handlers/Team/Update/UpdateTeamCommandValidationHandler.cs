using FootballLeague.Common.Validation;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Team.Update;
using FootballLeague.Services.Results.Team.Update;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Update
{
    public class UpdateTeamCommandValidationHandler : ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult>
    {
        private readonly ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult> decoratee;
        private readonly IValidator<UpdateTeamCommand> validator;

        public UpdateTeamCommandValidationHandler(
            ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult> decoratee,
            IValidator<UpdateTeamCommand> validator)
        {
            this.decoratee = decoratee;
            this.validator = validator;
        }

        public async Task<UpdateTeamResult> Handle(UpdateTeamCommand command)
        {
            var result = validator.Validate(command);

            if (!result.IsSuccessful) return new UpdateTeamResult(result.ErrorMessage);

            return await decoratee.Handle(command);
        }
    }
}
