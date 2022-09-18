using FootballLeague.Contracts.Queries;
using System.Threading.Tasks;

namespace FootballLeague.Contracts.Handlers
{
    public interface IQueryHandlerAsync<TQuery, TResult>
        where TQuery : IQuery
    {
        Task<TResult> Handle(TQuery query);
    }
}
