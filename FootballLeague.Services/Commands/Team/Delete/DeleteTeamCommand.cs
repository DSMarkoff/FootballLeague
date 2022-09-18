using FootballLeague.Contracts.Commands;

namespace FootballLeague.Services.Commands.Team.Delete
{
    public class DeleteTeamCommand : ICommand
    {
        public DeleteTeamCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
