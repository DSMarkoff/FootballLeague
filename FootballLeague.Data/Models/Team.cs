using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Data.Models
{
    public class Team : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int Won { get; set; }

        public int Drawn { get; set; }

        public int Lost { get; set; }

        public int Played { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public int GoalDifference { get; set; }

        public int Points { get; set; }
    }
}
