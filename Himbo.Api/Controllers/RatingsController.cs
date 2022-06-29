using Himbo.Application.UseCases.Commands.Rating;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public RatingsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        #region CreateRating
        [HttpPost]
        public IActionResult CreateRating([FromBody] RatingDto dto, [FromServices] ICreateRatingCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region UpdateRating
        [HttpPut]
        public IActionResult UpdateRating([FromBody] RatingDto dto, [FromServices] IUpdateRatingCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        } 
        #endregion
    }
}
