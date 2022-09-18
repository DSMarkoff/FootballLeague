using System;

namespace FootballLeague.Models.Match.Update
{
    public class UpdateMatchInputModel
    {
        public int Id { get; set; }

        public DateTime End { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }
    }
}
