using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Commands.Match.Update;
using FootballLeague.Services.Commands.Team.Update;
using FootballLeague.Services.Results.Match.Update;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Update
{
    public class UpdateTeamsStatsHandler : ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult>
    {
        private readonly ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult> decoratee;
        private readonly ICommandHandlerAsync<UpdateTeamStatsCommand> updateTeamStatsHandler;
        public UpdateTeamsStatsHandler(
            ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult> decoratee,
            ICommandHandlerAsync<UpdateTeamStatsCommand> updateTeamStatsHandler)
        {
            this.decoratee = decoratee;
            this.updateTeamStatsHandler = updateTeamStatsHandler;
        }

        public async Task<UpdateMatchResult> Handle(UpdateMatchCommand command)
        {
            var updateHomeTeamStatsCommand =
                new UpdateTeamStatsCommand(command.Id, command.HomeTeamGoals, command.AwayTeamGoals, true);

            await updateTeamStatsHandler.Handle(updateHomeTeamStatsCommand);

            var updateAwayTeamStatsCommand =
                new UpdateTeamStatsCommand(command.Id, command.AwayTeamGoals, command.HomeTeamGoals, false);

            await updateTeamStatsHandler.Handle(updateAwayTeamStatsCommand);

            return await decoratee.Handle(command);
        }
    }
}
