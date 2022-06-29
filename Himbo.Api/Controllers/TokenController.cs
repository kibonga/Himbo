using Himbo.Api.Core.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager _manager;

        public TokenController(JwtManager manager)
        {
            this._manager = manager;
        }

        #region Login
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] TokenRequest request)
        {
            var token = _manager.AuthorizeAndMakeToken(request.Email, request.Password);
            return Ok(new { token });
        } 
        #endregion
    }

    public class TokenRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
