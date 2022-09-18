using FootballLeague.Contracts.Queries;

namespace FootballLeague.Services.Queries.Match.Get
{
    public class MatchByIdQuery : IQuery
    {
        public MatchByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
