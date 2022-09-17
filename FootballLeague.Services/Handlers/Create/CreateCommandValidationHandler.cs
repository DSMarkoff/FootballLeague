﻿using FootballLeague.Abstraction.Handlers;
using FootballLeague.Data;
using FootballLeague.Services.Commands.Create;
using FootballLeague.Services.Results.Create;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Handlers.Create
{
    public class CreateCommandValidationHandler : ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>
    {
        private const string NAME_ALREADY_EXISTS = "A team with such a name already exists.";

        private readonly ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> decoratee;
        private readonly AppDbContext dbContext;

        public CreateCommandValidationHandler(
            ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> decoratee,
            AppDbContext dbContext)
        {
            this.decoratee = decoratee;
            this.dbContext = dbContext;
        }

        public async Task<CreateTeamResult> Handle(CreateTeamCommand command)
        {
            var isЕxisting = dbContext.Teams.Any(t => t.Name == command.Name);

            if (isЕxisting) return new CreateTeamResult(NAME_ALREADY_EXISTS);

            return await decoratee.Handle(command);
        }
    }
}
