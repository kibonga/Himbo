using Himbo.Application.UseCases.Commands.Group;
using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Group;
using Himbo.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public GroupsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        #region CreateGroup
        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupDto dto, [FromServices] ICreateGroupCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region AddGroupUseCases
        [HttpPost("usecases/add")]
        public IActionResult AddGroupUseCases([FromBody] GroupUseCasesIdsDto dto, [FromServices] IAddGroupUseCasesCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        #endregion

        #region RemoveGroupUseCases
        [HttpPost("usecases/remove")]
        public IActionResult RemoveGroupUseCases([FromBody] GroupUseCasesIdsDto dto, [FromServices] IRemoveGroupUseCasesCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        #endregion

        #region DeactivateGroup
        [HttpDelete("deactivate/{id}")]
        public IActionResult DeactivateGroup(int id, [FromServices] IDeactivateGroupCommand command)
        {

            _handler.HandleCommand(command, id);
            return NoContent();
        }
        #endregion

        #region ActivateGroup
        [HttpPatch("activate/{id}")]
        public IActionResult ActivateGroup(int id, [FromServices] IActivateGroupCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
        #endregion

        #region GetAllGroups
        [HttpGet]
        public IActionResult GetAllGroups([FromQuery] BasePagedSearch search, [FromServices] IGetGroupsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
        #endregion

        #region FindGroup
        [HttpGet("{id}")]
        public IActionResult FindGroup(int id, [FromServices] IFindGroupQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }
        #endregion

        #region GetAllUsersForGroup
        [HttpGet("{id}/users")]
        public IActionResult GetAllUsersForGroup(int id, [FromQuery] BasePagedSearch search, [FromServices] IGetGroupUsersQuery query)
        {
            return Ok(_handler.HandleQuery(id, query, search));
        }
        #endregion

        #region ChangeGroupForUser
        [HttpPost("change")]
        public IActionResult ChangeGroupForUser([FromBody] GroupDtoManager dto, [FromServices] IChangeUserGroupCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        } 
        #endregion
    }
}
