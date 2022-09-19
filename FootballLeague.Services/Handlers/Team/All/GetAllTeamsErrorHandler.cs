using FootballLeague.Common.Logging;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Queries.Team.All;
using FootballLeague.Services.Results.Team.All;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.All
{
    public class GetAllTeamsErrorHandler : IQueryHandlerAsync<GetAllTeamsQuery, GetAllTeamsResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly IQueryHandlerAsync<GetAllTeamsQuery, GetAllTeamsResult> decoratee;

        public GetAllTeamsErrorHandler(IQueryHandlerAsync<GetAllTeamsQuery, GetAllTeamsResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<GetAllTeamsResult> Handle(GetAllTeamsQuery query)
        {
            try
            {
                return await decoratee.Handle(query);
            }
            catch (Exception ex)
            {
                Logger.Log($"C/Q: {nameof(GetAllTeamsQuery)}, AT {DateTime.UtcNow}, {ex}");

                return new GetAllTeamsResult(GENERAL_ERROR);
            }
        }
    }
}
