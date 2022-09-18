using FootballLeague.Abstraction.Results;

namespace FootballLeague.Common.Validation
{
    public class ValidationResult : IResult
    {
        public ValidationResult()
        {
            IsSuccessful = true;
        }

        public ValidationResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }
    }
}
