using FootballLeague.Contracts.Results;

namespace FootballLeague.Services.Results.Match.Delete
{
    public class DeleteMatchResult : IResult
    {
        public DeleteMatchResult()
        {
            IsSuccessful = true;
        }

        public DeleteMatchResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }
    }
}
