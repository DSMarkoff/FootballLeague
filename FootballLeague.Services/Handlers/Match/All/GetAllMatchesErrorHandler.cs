using FootballLeague.Common.Logging;
using FootballLeague.Contracts.Handlers;
using FootballLeague.Services.Queries.Match.All;
using FootballLeague.Services.Results.Match.All;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.All
{
    public class GetAllMatchesErrorHandler : IQueryHandlerAsync<GetAllMatchesQuery, GetAllMatchesResult>
    {
        private const string GENERAL_ERROR = "An expected error has occurred.";

        private readonly IQueryHandlerAsync<GetAllMatchesQuery, GetAllMatchesResult> decoratee;

        public GetAllMatchesErrorHandler(IQueryHandlerAsync<GetAllMatchesQuery, GetAllMatchesResult> decoratee)
        {
            this.decoratee = decoratee;
        }

        public async Task<GetAllMatchesResult> Handle(GetAllMatchesQuery query)
        {
            try
            {
                return await decoratee.Handle(query);
            }
            catch (Exception ex)
            {
                Logger.Log($"C/Q: {nameof(GetAllMatchesQuery)}, AT {DateTime.UtcNow}, {ex}");

                return new GetAllMatchesResult(GENERAL_ERROR);
            }
        }
    }
}
