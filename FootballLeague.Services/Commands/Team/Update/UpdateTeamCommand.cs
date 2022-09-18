using FootballLeague.Contracts.Commands;

namespace FootballLeague.Services.Commands.Team.Update
{
    public class UpdateTeamCommand : ICommand
    {
        public UpdateTeamCommand(
            int id,
            string name,
            int won,
            int drawn,
            int lost,
            int goalsFor,
            int goalsAgainst)
        {
            Id = id;
            Name = name;
            Won = won;
            Drawn = drawn;
            Lost = lost;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
        }

        public int Id { get; }

        public string Name { get; }

        public int Won { get; }

        public int Drawn { get; }

        public int Lost { get; }

        public int GoalsFor { get; }

        public int GoalsAgainst { get; }
    }
}
