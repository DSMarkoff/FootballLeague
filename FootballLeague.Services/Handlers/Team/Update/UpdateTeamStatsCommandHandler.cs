using FootballLeague.Contracts.Enumerations;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Team.Update;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Update
{
    public class UpdateTeamStatsCommandHandler : ICommandHandlerAsync<UpdateTeamStatsCommand>
    {
        private readonly AppDbContext dbContext;

        public UpdateTeamStatsCommandHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(UpdateTeamStatsCommand command)
        {
            var team = await dbContext.Teams
                        .Join(dbContext.Matches.Where(m => m.Id == command.MatchId),
                            t => t.Id,
                            m => command.IsHomeTeam ? m.HomeTeamId : m.AwayTeamId,
                            (t, m) => t)
                        .FirstOrDefaultAsync();

            var matchGoalDifference = command.MatchGoalsFor - command.MatchGoalsAgainst;

            if (matchGoalDifference > 0)
            {
                team.Won++;
                team.Points += (int)MatchResult.Won;
            }
            else if (matchGoalDifference < 0)
            {
                team.Lost++;
            }
            else
            {
                team.Drawn++;
                team.Points += (int)MatchResult.Drawn;
            }

            team.Played++;
            team.GoalsFor += command.MatchGoalsFor;
            team.GoalsAgainst += command.MatchGoalsAgainst;
            team.GoalDifference += matchGoalDifference;

            await dbContext.SaveChangesAsync();
        }
    }
}
