using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Models.Match.Get;
using FootballLeague.Services.Queries.Match.All;
using FootballLeague.Services.Results.Match.All;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.All
{
    public class GetAllMatchesHandler : IQueryHandlerAsync<GetAllMatchesQuery, GetAllMatchesResult>
    {
        private readonly AppDbContext dbContext;

        public GetAllMatchesHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetAllMatchesResult> Handle(GetAllMatchesQuery query)
        {
            var matches = await dbContext.Matches
                        .Select(m => new GetMatchOutputModel
                            {
                                HomeTeamGoals = m.HomeTeamGoals,
                                AwayTeamGoals = m.AwayTeamGoals,
                                Start = m.Start,
                                End = m.End,
                                HomeTeamId = m.HomeTeamId,
                                AwayTeamId = m.AwayTeamId
                            })
                        .OrderByDescending(m => m.Start)
                        .ToListAsync();

            return new GetAllMatchesResult(matches);
        }
    }
}
