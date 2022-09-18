using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Models.Match.Get;
using FootballLeague.Services.Queries.Match.Get;
using FootballLeague.Services.Results.Match.Get;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Get
{
    public class GetMatchByIdHandler : IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult>
    {
        private readonly AppDbContext dbContext;

        public GetMatchByIdHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetMatchByIdResult> Handle(MatchByIdQuery query)
        {
            var match = await dbContext.Matches
                        .Where(m => m.Id == query.Id)
                        .Select(m => new GetMatchOutputModel
                        {
                            HomeTeamGoals = m.HomeTeamGoals,
                            AwayTeamGoals = m.AwayTeamGoals,
                            Start = m.Start,
                            End = m.End,
                            HomeTeamId = m.HomeTeamId,
                            AwayTeamId = m.AwayTeamId
                        })
                        .FirstOrDefaultAsync();

            return new GetMatchByIdResult(match);
        }
    }
}
