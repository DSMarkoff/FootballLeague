using FootballLeague.Abstraction.Queries;

namespace FootballLeague.Services.Queries.Team.Get
{
    public class TeamByIdQuery : IQuery
    {
        public TeamByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
