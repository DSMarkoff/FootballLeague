using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeague.Data.Models
{
    public class Match : BaseEntity
    {
        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        [ForeignKey(nameof(Team))]
        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        [ForeignKey(nameof(Team))]
        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }
    }
}
