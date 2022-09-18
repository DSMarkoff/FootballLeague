using FootballLeague.Contracts.Results;

namespace FootballLeague.Services.Results.Match.Create
{
    public class CreateMatchResult : IResult
    {
        public CreateMatchResult()
        {
            IsSuccessful = true;
        }

        public CreateMatchResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }
    }
}
