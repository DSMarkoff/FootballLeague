using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Match.Update;
using FootballLeague.Services.Results.Match.Update;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Update
{
    public class UpdateMatchHandler : ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult>
    {
        private readonly AppDbContext dbContext;

        public UpdateMatchHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UpdateMatchResult> Handle(UpdateMatchCommand command)
        {
            var match = await dbContext.Matches
                        .Where(m => m.Id == command.Id)
                        .FirstOrDefaultAsync();

            match.End = command.End;
            match.HomeTeamGoals = command.HomeTeamGoals;
            match.AwayTeamGoals = command.AwayTeamGoals;

            await dbContext.SaveChangesAsync();

            return new UpdateMatchResult();
        }
    }
}
