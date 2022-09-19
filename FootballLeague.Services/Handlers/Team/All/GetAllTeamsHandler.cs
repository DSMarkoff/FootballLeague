using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Models.Team.Get;
using FootballLeague.Services.Queries.Team.All;
using FootballLeague.Services.Results.Team.All;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.All
{
    public class GetAllTeamsHandler : IQueryHandlerAsync<GetAllTeamsQuery, GetAllTeamsResult>
    {
        private readonly AppDbContext dbContext;

        public GetAllTeamsHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetAllTeamsResult> Handle(GetAllTeamsQuery query)
        {
            var teams = await dbContext.Teams
                        .Select(t => new GetTeamOutputModel
                            {
                                Name = t.Name,
                                Won = t.Won,
                                Drawn = t.Drawn,
                                Lost = t.Lost,
                                Played = t.Played,
                                GoalsFor = t.GoalsFor,
                                GoalsAgainst = t.GoalsAgainst,
                                GoalDifference = t.GoalDifference,
                                Points = t.Points
                            })
                        .OrderByDescending(t => t.Points)
                        .ThenByDescending(t => t.GoalDifference)
                        .ThenByDescending(t => t.GoalsFor)
                        .ToListAsync();

            return new GetAllTeamsResult(teams);
        }
    }
}
