using FootballLeague.Contracts.Results;

namespace FootballLeague.Services.Results.Team.Update
{
    public class UpdateTeamResult : IResult
    {
        public UpdateTeamResult()
        {
            IsSuccessful = true;
        }

        public UpdateTeamResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }
    }
}
