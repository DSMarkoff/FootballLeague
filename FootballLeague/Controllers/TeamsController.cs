using FootballLeague.Abstraction.Handlers;
using FootballLeague.Models.Team.Create;
using FootballLeague.Models.Team.Delete;
using FootballLeague.Models.Team.Get;
using FootballLeague.Models.Team.Update;
using FootballLeague.Services.Commands.Team.Create;
using FootballLeague.Services.Commands.Team.Delete;
using FootballLeague.Services.Commands.Team.Update;
using FootballLeague.Services.Queries.Team.Get;
using FootballLeague.Services.Results.Team.Create;
using FootballLeague.Services.Results.Team.Delete;
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
        private readonly ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult> deleteTeamHandler;

        public TeamsController(
            IQueryHandlerAsync<TeamByIdQuery, GetTeamByIdResult> getTeamHandler,
            ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> createTeamHandler,
            ICommandHandlerAsync<UpdateTeamCommand, UpdateTeamResult> updateTeamHandler,
            ICommandHandlerAsync<DeleteTeamCommand, DeleteTeamResult> deleteTeamHandler)
        {
            this.getTeamHandler = getTeamHandler;
            this.createTeamHandler = createTeamHandler;
            this.updateTeamHandler = updateTeamHandler;
            this.deleteTeamHandler = deleteTeamHandler;
        }

        /// <summary>
        /// Creates a Team.
        /// </summary>
        /// <response code="201">On success</response>
        /// <response code="400">On failure</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]CreateTeamInputModel model)
        {
            var command = new CreateTeamCommand(model.Name);

            var result = await createTeamHandler.Handle(command);

            if (result.IsSuccessful) return StatusCode(StatusCodes.Status201Created);

            return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        }

        /// <summary>
        /// Gets a Team.
        /// </summary>
        /// <response code="200">On success</response>
        /// <response code="400">On failure</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery]GetTeamInputModel model)
        {
            var query = new TeamByIdQuery(model.Id);

            var result = await getTeamHandler.Handle(query);

            if (result.IsSuccessful) return StatusCode(StatusCodes.Status200OK, result.Team);

            return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        }

        /// <summary>
        /// Updates a Team.
        /// </summary>
        /// <response code="204">On success</response>
        /// <response code="400">On failure</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Deletes a Team.
        /// </summary>
        /// <response code="204">On success</response>
        /// <response code="400">On failure</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove([FromQuery] DeleteTeamInputModel model)
        {
            var command = new DeleteTeamCommand(model.Id);

            var result = await deleteTeamHandler.Handle(command);

            if (result.IsSuccessful) return StatusCode(StatusCodes.Status204NoContent);

            return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        }
    }
}
