using Himbo.Application.UseCases;
using Himbo.Application.UseCases.Commands.UseCase;
using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.UseCase;
using Himbo.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UseCasesController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public UseCasesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        #region CreateUseCase
        [HttpPost]
        public IActionResult CreateUseCase([FromBody] UseCaseDto dto, [FromServices] ICreateUseCaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region GetUseCasesForGroup
        [HttpGet("groups/{id}")]
        public IActionResult GetUseCasesForGroup(int id, [FromQuery] BasePagedSearch search, [FromServices] IGetUseCasesQuery query)
        {
            return Ok(_handler.HandleQuery(id, query, search));
        }
        #endregion

        #region AddForbiddenUseCasesToUser
        [HttpPost("add/forbidden")]
        public IActionResult AddForbiddenUseCasesToUser([FromBody] UseCaseDtoManager dto, [FromServices] IAddForbiddenUseCaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region RemoveForbiddenUseCasesForUser
        [HttpPost("remove/forbidden")]
        public IActionResult RemoveForbiddenUseCasesForUser([FromBody] UseCaseDtoManager dto, [FromServices] IRemoveForbiddenUseCaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        #endregion

        #region AddAdditionalUseCasesToUser
        [HttpPost("add/additional")]
        public IActionResult AddAdditionalUseCasesToUser([FromBody] UseCaseDtoManager dto, [FromServices] IAddAdditionalUseCaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region RemoveAdditionalUseCasesFromUser
        [HttpPost("remove/additional")]
        public IActionResult RemoveAdditionalUseCasesFromUser([FromBody] UseCaseDtoManager dto, [FromServices] IRemoveAdditionalUseCaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        #endregion

        #region GetAllAdditionalUseCasesForUser
        [HttpGet("additional/users/{id}")]
        public IActionResult GetAllAdditionalUseCasesForUser(int id, [FromQuery] BasePagedSearch search, [FromServices] IGetAdditionalUseCasesQuery query)
        {
            return Ok(_handler.HandleQuery(id, query, search));
        }
        #endregion

        #region GetAllForbiddenUseCasesForUser
        [HttpGet("forbidden/users/{id}")]
        public IActionResult GetAllForbiddenUseCasesForUser(int id, [FromQuery] BasePagedSearch search, [FromServices] IGetForbiddenUseCasesQuery query)
        {
            return Ok(_handler.HandleQuery(id, query, search));
        }
        #endregion

        #region GetAllUseCaseLogs
        [HttpGet("logs")]
        public IActionResult GetAllUseCaseLogs([FromQuery] UseCaseLogSearch search, [FromServices] IGetUseCaseLogsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        } 
        #endregion

    }
}
