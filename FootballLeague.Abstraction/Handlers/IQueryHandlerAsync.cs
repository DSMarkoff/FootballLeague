using FootballLeague.Abstraction.Queries;
using System.Threading.Tasks;

namespace FootballLeague.Abstraction.Handlers
{
    public interface IQueryHandlerAsync<TQuery, TResult>
        where TQuery : IQuery
    {
        Task<TResult> Handle(TQuery query);
    }
}
