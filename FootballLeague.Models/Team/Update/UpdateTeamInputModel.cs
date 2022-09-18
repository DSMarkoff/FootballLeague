namespace FootballLeague.Models.Team.Update
{
    public class UpdateTeamInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Won { get; set; }

        public int Drawn { get; set; }

        public int Lost { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }
    }
}
