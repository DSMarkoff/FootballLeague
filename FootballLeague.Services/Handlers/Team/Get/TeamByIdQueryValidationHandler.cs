using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Queries.Team.Get;
using FootballLeague.Services.Results.Team.Get;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Get
{
    public class TeamByIdQueryValidationHandler : IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult>
    {
        private const string NONEXISTENT_TEAM = "A team with such an Id does not exist.";

        private readonly IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult> decoratee;
        private readonly AppDbContext dbContext;

        public TeamByIdQueryValidationHandler(
            IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult> decoratee,
            AppDbContext dbContext)
        {
            this.decoratee = decoratee;
            this.dbContext = dbContext;
        }

        public async Task<GetTeamByIdResult> Handle(TeamByIdQuery query)
        {
            var isЕxisting = dbContext.Teams.Any(t => t.Id == query.Id);

            if (!isЕxisting) return new GetTeamByIdResult(NONEXISTENT_TEAM);

            return await decoratee.Handle(query);
        }
    }
}
