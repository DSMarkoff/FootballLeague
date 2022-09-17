using FootballLeague.Abstraction.Results;

namespace FootballLeague.Services.Results.Create
{
    public class CreateTeamResult : IResult
    {
        public CreateTeamResult()
        {
            IsSuccessful = true;
        }

        public CreateTeamResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }
    }
}
