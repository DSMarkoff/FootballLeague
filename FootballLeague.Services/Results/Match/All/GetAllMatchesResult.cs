using FootballLeague.Contracts.Results;
using FootballLeague.Models.Match.Get;
using System.Collections.Generic;

namespace FootballLeague.Services.Results.Match.All
{
    public class GetAllMatchesResult : IResult
    {
        public GetAllMatchesResult(ICollection<GetMatchOutputModel> matches)
        {
            IsSuccessful = true;
            Matches = matches;
        }

        public GetAllMatchesResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }

        public ICollection<GetMatchOutputModel> Matches { get; }
    }
}
