using System;

namespace FootballLeague.Models.Match.Get
{
    public class GetMatchOutputModel
    {
        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }
    }
}
