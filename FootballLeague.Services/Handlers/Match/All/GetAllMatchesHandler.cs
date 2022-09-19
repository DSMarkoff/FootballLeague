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
                            .Join(dbContext.Teams,
                                m => m.HomeTeamId,
                                t => t.Id,
                                (m, t) =>
                                    new
                                    {
                                        Id = m.Id,
                                        HomeTeamGoals = m.HomeTeamGoals,
                                        AwayTeamGoals = m.AwayTeamGoals,
                                        Start = m.Start,
                                        End = m.End,
                                        HomeTeamId = m.HomeTeamId,
                                        AwayTeamId = m.AwayTeamId,
                                        HomeTeamName = t.Name
                                    })
                                    .Join(dbContext.Teams,
                                        j => j.AwayTeamId,
                                        t => t.Id,
                                        (j, t) =>
                                            new GetMatchOutputModel
                                            {
                                                Id = j.Id,
                                                HomeTeamGoals = j.HomeTeamGoals,
                                                AwayTeamGoals = j.AwayTeamGoals,
                                                Start = j.Start,
                                                End = j.End,
                                                HomeTeamId = j.HomeTeamId,
                                                AwayTeamId = j.AwayTeamId,
                                                HomeTeamName = j.HomeTeamName,
                                                AwayTeamName = t.Name
                                            })
                            .OrderByDescending(m => m.Start)
                            .ToListAsync();

            return new GetAllMatchesResult(matches);
        }
    }
}
