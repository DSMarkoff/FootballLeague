using System.Threading.Tasks;
using System.Windows.Input;

namespace FootballLeague.Abstraction.Handlers
{
    public interface ICommandHandlerAsync<TCommand, TResult>
        where TCommand : ICommand
    {
        Task<TResult> Handle(TCommand command);
    }
}
