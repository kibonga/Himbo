using Himbo.Application.UseCases.Commands.Auth;
using Himbo.Application.UseCases.DTO;
using Himbo.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly IRegisterUserCommand _command;

        public RegisterController
        (
            UseCaseHandler handler,
            IRegisterUserCommand command
        )
        {
            _handler = handler;
            _command = command;
        }

        #region Register - Anonymous
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            _handler.HandleCommand(_command, dto);
            return StatusCode(StatusCodes.Status201Created);
        } 
        #endregion
    }
}
