using Himbo.Api.Core.Dto;
using Himbo.Api.FileUpload;
using Himbo.Application.UseCases.Commands.Category;
using Himbo.Application.UseCases.DTO;
using Himbo.Application.UseCases.DTO.Searches;
using Himbo.Application.UseCases.Queries.Category;
using Himbo.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public CategoriesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        #region CreateCategory
        [HttpPost]
        public IActionResult CreateCategory([FromForm] CategoryDtoWithImage dto, [FromServices] ICreateCategoryCommand command, [FromServices] IFileUploader uploader)
        {

            #region Upload Image
            if (dto.File != null)
            {
                var fileName = uploader.Upload(dto.File);
                dto.ImageFileName = fileName;
            }
            #endregion

            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region UpdateCategory
        [HttpPut]
        public IActionResult UpdateCategory([FromForm] CategoryDtoWithImage dto, [FromServices] IUpdateCategoryCommand command, [FromServices] IFileUploader uploader)
        {
            #region Upload Image
            if (dto.File != null)
            {
                var fileName = uploader.Upload(dto.File);
                dto.ImageFileName = fileName;
            }
            #endregion

            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        #endregion

        #region DeactivateCategory
        [HttpDelete("deactivate/{id}")]
        public IActionResult DeactivateCategory(int id, [FromServices] IDeactivateCategoryCommand command)
        {

            _handler.HandleCommand(command, id);
            return NoContent();
        }
        #endregion

        #region ActivateCategory
        [HttpPatch("activate/{id}")]
        public IActionResult ActivateCategory(int id, [FromServices] IActivateCategoryCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
        #endregion

        #region GetAllCategories - Anonymous
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
        #endregion

        #region FindCategory - Anonymous
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult FindCategory(int id, [FromServices] IFindCategoryQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }
        #endregion

        #region DeleteCategory
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        } 
        #endregion

    }
}
