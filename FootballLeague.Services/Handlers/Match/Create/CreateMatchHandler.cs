using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Match.Create;
using FootballLeague.Services.Results.Match.Create;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Create
{
    public class CreateMatchHandler : ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>
    {
        private readonly AppDbContext dbContext;

        public CreateMatchHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CreateMatchResult> Handle(CreateMatchCommand command)
        {
            var match =
                new Data.Models.Match
                {
                    Start = command.Start,
                    HomeTeamId = command.HomeTeamId,
                    AwayTeamId = command.AwayTeamId
                };

            await dbContext.Matches.AddAsync(match);
            await dbContext.SaveChangesAsync();

            return new CreateMatchResult();
        }
    }
}
