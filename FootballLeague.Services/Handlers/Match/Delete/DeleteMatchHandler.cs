using FootballLeague.Contracts.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Match.Delete;
using FootballLeague.Services.Results.Match.Delete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Match.Delete
{
    public class DeleteMatchHandler : ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult>
    {
        private readonly AppDbContext dbContext;

        public DeleteMatchHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DeleteMatchResult> Handle(DeleteMatchCommand command)
        {
            var match = await dbContext.Matches
                        .Where(m => m.Id == command.Id)
                        .FirstOrDefaultAsync();

            dbContext.Remove(match);
            await dbContext.SaveChangesAsync();

            return new DeleteMatchResult();
        }
    }
}
