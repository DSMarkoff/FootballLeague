using FootballLeague.Contracts.Results;

namespace FootballLeague.Services.Results.Match.Update
{
    public class UpdateMatchResult : IResult
    {
        public UpdateMatchResult()
        {
            IsSuccessful = true;
        }

        public UpdateMatchResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }
    }
}
