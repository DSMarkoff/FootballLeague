using FootballLeague.Abstraction.Commands;
using System.Threading.Tasks;

namespace FootballLeague.Abstraction.Handlers
{
    public interface ICommandHandlerAsync<TCommand, TResult>
        where TCommand : ICommand
    {
        Task<TResult> Handle(TCommand command);
    }
}
