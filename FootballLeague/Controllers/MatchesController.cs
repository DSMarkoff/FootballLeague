using FootballLeague.Contracts.Handlers;
using FootballLeague.Models.Match.Create;
//using FootballLeague.Models.Match.Delete;
using FootballLeague.Models.Match.Get;
using FootballLeague.Models.Match.Update;
using FootballLeague.Services.Commands.Match.Create;
//using FootballLeague.Services.Commands.Match.Delete;
using FootballLeague.Services.Commands.Match.Update;
using FootballLeague.Services.Queries.Match.Get;
using FootballLeague.Services.Results.Match.Create;
using FootballLeague.Services.Results.Match.Get;
using FootballLeague.Services.Results.Match.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    public class MatchesController : ApiControllerBase
    {
        private readonly IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult> getMatchHandler;
        private readonly ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> createMatchHandler;
        private readonly ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult> updateMatchHandler;
        //private readonly ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult> deleteMatchHandler;

        public MatchesController(
            IQueryHandlerAsync<MatchByIdQuery, GetMatchByIdResult> getMatchHandler,
            ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> createMatchHandler,
            ICommandHandlerAsync<UpdateMatchCommand, UpdateMatchResult> updateMatchHandler)
            //ICommandHandlerAsync<DeleteMatchCommand, DeleteMatchResult> deleteMatchHandler)
        {
            this.getMatchHandler = getMatchHandler;
            this.createMatchHandler = createMatchHandler;
            this.updateMatchHandler = updateMatchHandler;
            //this.deleteMatchHandler = deleteMatchHandler;
        }

        /// <summary>
        /// Creates a Match.
        /// </summary>
        /// <response code="201">On success</response>
        /// <response code="400">On failure</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateMatchInputModel model)
        {
            var command = new CreateMatchCommand(model.Start, model.HomeTeamId, model.AwayTeamId);

            var result = await createMatchHandler.Handle(command);

            if (result.IsSuccessful) return StatusCode(StatusCodes.Status201Created);

            return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        }

        /// <summary>
        /// Gets a Match.
        /// </summary>
        /// <response code="200">On success</response>
        /// <response code="400">On failure</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] GetMatchInputModel model)
        {
            var query = new MatchByIdQuery(model.Id);

            var result = await getMatchHandler.Handle(query);

            if (result.IsSuccessful) return StatusCode(StatusCodes.Status200OK, result.Team);

            return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        }

        /// <summary>
        /// Updates a Match.
        /// </summary>
        /// <response code="204">On success</response>
        /// <response code="400">On failure</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateMatchInputModel model)
        {
            var command = new UpdateMatchCommand(
                            model.Id,
                            model.End,
                            model.HomeTeamGoals,
                            model.AwayTeamGoals);

            var result = await updateMatchHandler.Handle(command);

            if (result.IsSuccessful) return StatusCode(StatusCodes.Status204NoContent);

            return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        }

        ///// <summary>
        ///// Deletes a Match.
        ///// </summary>
        ///// <response code="204">On success</response>
        ///// <response code="400">On failure</response>
        //[HttpDelete]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Remove([FromQuery] DeleteMatchInputModel model)
        //{
        //    var command = new DeleteMatchCommand(model.Id);

        //    var result = await deleteMatchHandler.Handle(command);

        //    if (result.IsSuccessful) return StatusCode(StatusCodes.Status204NoContent);

        //    return StatusCode(StatusCodes.Status400BadRequest, result.ErrorMessage);
        //}
    }
}
