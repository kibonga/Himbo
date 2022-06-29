using Himbo.Application.UseCases.Commands.Like;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikesController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public LikesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        #region CreateLikeForPost
        [HttpPost("posts")]
        public IActionResult CreateLikeForPost([FromBody] LikeDtoPost dto, [FromServices] ICreatePostLikeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region CreateLikeForComment
        [HttpPost("comments")]
        public IActionResult CreateLikeForComment([FromBody] LikeDtoComment dto, [FromServices] ICreateCommentLikeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region DeleteLikeForPost
        [HttpDelete("posts/{postId}/user/{userId}")]
        public IActionResult DeleteLikeForPost(int postId, int userId, [FromServices] IDeletePostLikeCommand command)
        {
            _handler.HandleCommand(command, postId, userId);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        #endregion

        #region DeleteLikeForComment
        [HttpDelete("comments/{commentId}/user/{userId}")]
        public IActionResult DeleteLikeForComment(int commentId, int userId, [FromServices] IDeleteCommentLikeCommand command)
        {
            _handler.HandleCommand(command, commentId, userId);
            return StatusCode(StatusCodes.Status204NoContent);
        } 
        #endregion
    }
}
