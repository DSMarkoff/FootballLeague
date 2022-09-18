using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Models.Team.Get;
using FootballLeague.Services.Queries.Team.Get;
using FootballLeague.Services.Results.Team.Get;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Get
{
    public class GetTeamByIdHandler : IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult>
    {
        private readonly AppDbContext dbContext;

        public GetTeamByIdHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetTeamByIdResult> Handle(TeamByIdQuery query)
        {
            var team = await dbContext.Teams
                        .Where(t => t.Id == query.Id)
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
                        .FirstOrDefaultAsync();

            return new GetTeamByIdResult(team);
        }
    }
}
