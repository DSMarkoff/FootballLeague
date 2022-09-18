using FootballLeague.Contracts.Results;
using FootballLeague.Models.Match.Get;

namespace FootballLeague.Services.Results.Match.Get
{
    public class GetMatchByIdResult : IResult
    {
        public GetMatchByIdResult(GetMatchOutputModel team)
        {
            IsSuccessful = true;
            Team = team;
        }

        public GetMatchByIdResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }

        public GetMatchOutputModel Team { get; }
    }
}
