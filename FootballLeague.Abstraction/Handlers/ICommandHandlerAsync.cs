using FootballLeague.Contracts.Commands;
using System.Threading.Tasks;

namespace FootballLeague.Contracts.Handlers
{
    public interface ICommandHandlerAsync<TCommand, TResult>
        where TCommand : ICommand
    {
        Task<TResult> Handle(TCommand command);
    }

    public interface ICommandHandlerAsync<TCommand>
        where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}
