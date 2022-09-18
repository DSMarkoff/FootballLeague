using FootballLeague.Abstraction.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Team.Delete;
using FootballLeague.Services.Results.Team.Delete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Delete
{
    public class DeleteTeamHandler : ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult>
    {
        private readonly AppDbContext dbContext;

        public DeleteTeamHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DeleteTeamResult> Handle(DeleteTeamCommand command)
        {
            var team = await dbContext.Teams
                        .Where(t => t.Id == command.Id)
                        .FirstOrDefaultAsync();

            dbContext.Remove(team);
            await dbContext.SaveChangesAsync();

            return new DeleteTeamResult();
        }
    }
}
