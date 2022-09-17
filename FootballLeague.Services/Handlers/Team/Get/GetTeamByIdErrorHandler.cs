using FootballLeague.Abstraction.Handlers;
using FootballLeague.Services.Logging;
using FootballLeague.Services.Queries.Team.Get;
using FootballLeague.Services.Results.Team.Get;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Get
{
    public class GetTeamByIdErrorHandler : IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult> decoratee;

        public GetTeamByIdErrorHandler(IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<GetTeamByIdResult> Handle(TeamByIdQuery query)
        {
            try
            {
                return await decoratee.Handle(query);
            }
            catch (Exception ex)
            {
                Logger.Log($"{DateTime.UtcNow}, {ex}");

                return new GetTeamByIdResult(GENERAL_ERROR);
            }
        }
    }
}
