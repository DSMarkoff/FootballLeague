using FootballLeague.Abstraction.Handlers;
using FootballLeague.Models.Team.Create;
using FootballLeague.Models.Team.Get;
using FootballLeague.Models.Team.Update;
using FootballLeague.Services.Commands.Team.Create;
using FootballLeague.Services.Commands.Team.Update;
using FootballLeague.Services.Queries.Team.Get;
using FootballLeague.Services.Results.Team.Create;
using FootballLeague.Services.Results.Team.Get;
using FootballLeague.Services.Results.Team.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    public class TeamsController : ApiControllerBase
    {
        private readonly IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult> getTeamHandler; 
        private readonly ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> createTeamHandler;
        private readonly ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult> updateTeamHandler;

        public TeamsController(
            IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult> getTeamHandler,
            ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> createTeamHandler,
            ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult> updateTeamHandler)
        {
            this.getTeamHandler = getTeamHandler;
            this.createTeamHandler = createTeamHandler;
            this.updateTeamHandler = updateTeamHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateTeamInputModel model)
        {
            var command = new CreateTeamCommand(model.Name);

            var result = await createTeamHandler.Handle(command);

            if (result.IsSuccessful) return StatusCode(StatusCodes.Status201Created);

            return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetTeamInputModel model)
        {
            var query = new TeamByIdQuery(model.Id);

            var result = await getTeamHandler.Handle(query);

            if (result.IsSuccessful) return StatusCode(StatusCodes.Status200OK, result.Team);

            return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateTeamInputModel model)
        {
            var command = new UpdateTeamCommand(
                            model.Id,
                            model.Name,
                            model.Won,
                            model.Drawn,
                            model.Lost,
                            model.GoalsFor,
                            model.GoalsAgainst);

            var result = await updateTeamHandler.Handle(command);

            if (result.IsSuccessful) return StatusCode(StatusCodes.Status204NoContent);

            return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        }

        //[HttpDelete]
        //public async Task<IActionResult> Remove()
        //{

        //}
    }
}
