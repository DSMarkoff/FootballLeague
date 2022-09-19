using FootballLeague.Contracts.Commands;

namespace FootballLeague.Services.Commands.Team.Update
{
    public class UpdateTeamStatsCommand : ICommand
    {
        public UpdateTeamStatsCommand(
            int matchId,
            int matchGoalsFor,
            int matchGoalsAgainst,
            bool isHomeTeam)
        {
            MatchId = matchId;
            MatchGoalsFor = matchGoalsFor;
            MatchGoalsAgainst = matchGoalsAgainst;
            IsHomeTeam = isHomeTeam;
        }

        public int MatchId { get; }

        public int MatchGoalsFor { get; }

        public int MatchGoalsAgainst { get; }

        public bool IsHomeTeam { get; }
    }
}
