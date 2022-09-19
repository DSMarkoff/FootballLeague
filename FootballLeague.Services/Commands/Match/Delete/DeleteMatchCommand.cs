using FootballLeague.Contracts.Commands;

namespace FootballLeague.Services.Commands.Match.Delete
{
    public class DeleteMatchCommand : ICommand
    {
        public DeleteMatchCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
