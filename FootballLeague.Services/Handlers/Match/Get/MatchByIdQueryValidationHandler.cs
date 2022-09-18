using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Queries.Match.Get;
using FootballLeague.Services.Results.Match.Get;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Get
{
    public class MatchByIdQueryValidationHandler : IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult>
    {
        private const string NONEXISTENT_MATCH = "A match with such an Id does not exist.";

        private readonly IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult> decoratee;
        private readonly AppDbContext dbContext;

        public MatchByIdQueryValidationHandler(
            IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult> decoratee,
            AppDbContext dbContext)
        {
            this.decoratee = decoratee;
            this.dbContext = dbContext;
        }

        public async Task<GetMatchByIdResult> Handle(MatchByIdQuery query)
        {
            var isЕxisting = dbContext.Matches.Any(m => m.Id == query.Id);

            if (!isЕxisting) return new GetMatchByIdResult(NONEXISTENT_MATCH);

            return await decoratee.Handle(query);
        }
    }
}
