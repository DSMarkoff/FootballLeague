using FootballLeague.Contracts.Results;
using FootballLeague.Models.Team.Get;
using System.Collections.Generic;

namespace FootballLeague.Services.Results.Team.All
{
    public class GetAllTeamsResult : IResult
    {
        public GetAllTeamsResult(ICollection<GetTeamOutputModel> teams)
        {
            IsSuccessful = true;
            Teams = teams;
        }

        public GetAllTeamsResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }

        public ICollection<GetTeamOutputModel> Teams { get; }
    }
}
