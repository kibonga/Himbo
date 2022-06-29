using Himbo.Application.UseCases.Commands.Comment;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Comment;
using Himbo.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public CommentsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        #region CreateComment
        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentDto dto, [FromServices] ICreateCommentCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region GetCommentsForSinglePost - Anonymous
        [HttpGet("posts/{id}")]
        [AllowAnonymous]
        public IActionResult GetCommentsForSinglePost(int id, [FromQuery] BasePagedSearch search, [FromServices] IGetCommentsQuery query)
        {
            return Ok(_handler.HandleQuery(id, query, search));
        }
        #endregion

        #region UpdateComment
        [HttpPut]
        public IActionResult Put([FromBody] CommentDtoUpdate dto, [FromServices] IUpdateCommentCommand command)
        {
            _handler.HandleCommand<CommentDtoUpdate>(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        #endregion

        #region DeactivateComment
        [HttpDelete("deactivate/{id}")]
        public IActionResult DeactivateComment(int id, [FromServices] IDeactivateCommentCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
        #endregion

        #region ActivateComment
        [HttpPatch("activate/{id}")]
        public IActionResult ActivateComment(int id, [FromServices] IActivateCommentCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        } 
        #endregion
    }
}
