using Himbo.Application.UseCases.Commands.Tag;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Tag;
using Himbo.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public TagsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        #region CreateTag
        [HttpPost]
        public IActionResult CreateTag([FromBody] TagDto dto, [FromServices] ICreateTagCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region UpdateTag
        [HttpPut]
        public IActionResult UpdateTag([FromBody] TagDto dto, [FromServices] IUpdateTagCommand command)
        {
            _handler.HandleCommand<TagDto>(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        #endregion

        #region DeleteTag
        [HttpDelete("{id}")]
        public IActionResult DeleteTag(int id, [FromServices] IDeleteTagCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
        #endregion

        #region GetAllTags - Anonymous
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllTags([FromQuery] BasePagedSearch search, [FromServices] IGetTagsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
        #endregion

        #region FindTag - Anonymous
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult FindTag(int id, [FromServices] IFindTagQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }
        #endregion

        #region DeactivateTag
        [HttpDelete("deactivate/{id}")]
        public IActionResult DeactivateTags(int id, [FromServices] IDeactivateTagCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
        #endregion

        #region ActivateTag
        [HttpPatch("activate/{id}")]
        public IActionResult ActivateTag(int id, [FromServices] IActivateTagCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        } 
        #endregion
    }
}
