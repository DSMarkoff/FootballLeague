using FootballLeague.Common.Logging;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Queries.Match.Get;
using FootballLeague.Services.Results.Match.Get;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Get
{
    public class GetMatchByIdErrorHandler : IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult> decoratee;

        public GetMatchByIdErrorHandler(IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<GetMatchByIdResult> Handle(MatchByIdQuery query)
        {
            try
            {
                return await decoratee.Handle(query);
            }
            catch (Exception ex)
            {
                Logger.Log($"C/Q: {nameof(MatchByIdQuery)}, AT {DateTime.UtcNow}, {ex}");

                return new GetMatchByIdResult(GENERAL_ERROR);
            }
        }
    }
}
