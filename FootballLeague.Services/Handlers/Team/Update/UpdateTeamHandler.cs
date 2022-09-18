using FootballLeague.Abstraction.Enumerations;
using FootballLeague.Abstraction.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Team.Update;
using FootballLeague.Services.Results.Team.Update;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Update
{
    public class UpdateTeamHandler : ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult>
    {
        private readonly AppDbContext dbContext;

        public UpdateTeamHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UpdateTeamResult> Handle(UpdateTeamCommand command)
        {
            var team = await dbContext.Teams
                        .Where(t => t.Id == command.Id)
                        .FirstOrDefaultAsync();

            var played = command.Won + command.Drawn + command.Lost;
            var goalDifference = command.GoalsFor - command.GoalsAgainst;
            var points = (int)MatchResult.Won * command.Won + (int)MatchResult.Drawn * command.Drawn;

            team.Name = command.Name;
            team.Won = command.Won;
            team.Drawn = command.Drawn;
            team.Lost = command.Lost;
            team.Played = played;
            team.GoalsFor = command.GoalsFor;
            team.GoalsAgainst = command.GoalsAgainst;
            team.GoalDifference = goalDifference;
            team.Points = points;

            await dbContext.SaveChangesAsync();

            return new UpdateTeamResult();
        }
    }
}
