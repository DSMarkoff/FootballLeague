using FootballLeague.Abstraction.Results;
using FootballLeague.Models.Team.Get;

namespace FootballLeague.Services.Results.Team.Get
{
    public class GetTeamByIdResult : IResult
    {
        public GetTeamByIdResult(GetTeamOutputModel team)
        {
            IsSuccessful = true;
            Team = team;
        }

        public GetTeamByIdResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }

        public string ErrorMessage { get; }

        public GetTeamOutputModel Team { get; }
    }
}
