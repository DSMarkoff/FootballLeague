using FootballLeague.Abstraction.Handlers;
using FootballLeague.Data;
using FootballLeague.Data.Models;
using FootballLeague.Services.Commands.Create;
using FootballLeague.Services.Results.Create;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Create
{
    public class CreateTeamHandler : ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>
    {
        private readonly AppDbContext dbContext;

        public CreateTeamHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CreateTeamResult> Handle(CreateTeamCommand command)
        {
            await dbContext.Teams.AddAsync(new Team
                                            {
                                                Name = command.Name
                                            });

            await dbContext.SaveChangesAsync();

            return new CreateTeamResult();
        }
    }
}
