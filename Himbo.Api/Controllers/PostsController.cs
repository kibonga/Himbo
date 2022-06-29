using Himbo.Api.Core.Dto;
using Himbo.Api.FileUpload;
using Himbo.Application.UseCases.Commands.Post;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Post;
using Himbo.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public PostsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        #region CreatePost
        [HttpPost]
        public IActionResult CreatePost([FromForm] PostDtoWithImage dto, [FromServices] ICreatePostCommand command, [FromServices] IFileUploader uploader)
        {
            #region Upload Banner Image
            if (dto.File != null)
            {
                var fileName = uploader.Upload(dto.File);
                dto.ImageFileName = fileName;
            }
            #endregion

            #region Upload Multiple Images
            if (dto.Files != null && dto.Files.Any())
            {
                var fileNames = uploader.UploadMany(dto.Files);
                dto.ImageFileNames = fileNames;
            }
            #endregion

            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region UpdatePost
        [HttpPut]
        public IActionResult UpdatePost([FromForm] PostDtoWithImage dto, [FromServices] IUpdatePostCommand command, [FromServices] IFileUploader uploader)
        {
            #region Upload Banner Image
            if (dto.File != null)
            {
                var fileName = uploader.Upload(dto.File);
                dto.ImageFileName = fileName;
            }
            #endregion

            #region Upload Multiple Images
            if (dto.Files != null && dto.Files.Any())
            {
                var fileNames = uploader.UploadMany(dto.Files);
                dto.ImageFileNames = fileNames;
            }
            #endregion

            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        #endregion

        #region DeletePost
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id, [FromServices] IDeletePostCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
        #endregion

        #region GetAllPosts - Anonymous
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllPosts([FromQuery] BasePagedSearch search, [FromServices] IGetPostsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
        #endregion

        #region FindPost - Anonymous
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult FindPost(int id, [FromServices] IFindPostQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }
        #endregion

        #region DeactivatePost
        [HttpDelete("deactivate/{id}")]
        public IActionResult DeactivatePost(int id, [FromServices] IDeactivatePostCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
        #endregion

        #region ActivatePost
        [HttpPatch("activate/{id}")]
        public IActionResult ActivatePost(int id, [FromServices] IActivatePostCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        } 
        #endregion
    }
}
