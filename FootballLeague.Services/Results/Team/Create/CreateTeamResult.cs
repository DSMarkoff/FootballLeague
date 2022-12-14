using FootballLeague.Contracts.Results;

namespace FootballLeague.Services.Results.Team.Create
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
