using System;

namespace FootballLeague.Models.Match.Create
{
    public class CreateMatchInputModel
    {
        public DateTime Start { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }
    }
}
