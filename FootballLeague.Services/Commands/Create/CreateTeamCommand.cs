using FootballLeague.Abstraction.Commands;

namespace FootballLeague.Services.Commands.Create
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
