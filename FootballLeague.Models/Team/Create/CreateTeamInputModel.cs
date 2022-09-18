using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Models.Team.Create
{
    public class CreateTeamInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
