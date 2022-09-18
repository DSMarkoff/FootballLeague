using FootballLeague.Contracts.Results;

namespace FootballLeague.Services.Results.Team.Delete
{
    public class DeleteTeamResult : IResult
    {
        public DeleteTeamResult()
        {
            IsSuccessful = true;
        }

        public DeleteTeamResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }
    }
}
