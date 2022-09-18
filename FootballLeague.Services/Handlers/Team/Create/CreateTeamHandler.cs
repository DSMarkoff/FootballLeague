using FootballLeague.Abstraction.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Team.Create;
using FootballLeague.Services.Results.Team.Create;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Team.Create
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
            var team = 
                new Data.Models.Team
                {
                    Name = command.Name
                };

            await dbContext.Teams.AddAsync(team);
            await dbContext.SaveChangesAsync();

            return new CreateTeamResult();
        }
    }
}
