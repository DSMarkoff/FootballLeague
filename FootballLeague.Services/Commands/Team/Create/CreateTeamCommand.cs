using FootballLeague.Contracts.Commands;

namespace FootballLeague.Services.Commands.Team.Create
{
    public class CreateTeamCommand : ICommand
    {
        public CreateTeamCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
