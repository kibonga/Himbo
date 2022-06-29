using Himbo.Application.Exceptions;
using Himbo.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Himbo.Api.Core.Jwt
{
    public class JwtManager // Used for Login (defined in Api layer, not in layers below, unlike Register)
    {
        private readonly HimboDbContext _context;
        private readonly JwtSettings _settings;

        public JwtManager(HimboDbContext context, JwtSettings settings)
        {
            _context = context;
            _settings = settings;
        }

        public string AuthorizeAndMakeToken(string email, string password)
        {
            #region Check if User Exists
            // TODO: Made changes
            var user = _context.Users
                .Include(x => x.AdditionalUseCases)
                .Include(x => x.ForbiddenUseCases)
                .Include(x => x.Group)
                .ThenInclude(x => x.UseCases)
                .FirstOrDefault(u => u.Email == email);
            if (user is null)
            {
                throw new AuthenticationFailedException("Email or password are invalid.");
            }
            #endregion

            #region Check if Passwords match
            var isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!isValid)
            {
                throw new AuthenticationFailedException("Email or password are invalid.");
            }
            #endregion

            // User credentials Part

            #region Create User
            var actor = new JwtUser
            {
                Id = user.Id,
                AdditionalUseCaseIds = user.AdditionalUseCases.Select(x => x.Id).ToList(),
                ForbiddenUseCaseIds  = user.ForbiddenUseCases.Select(x => x.Id).ToList(),
                AllowedUseCaseIds = user.Group.UseCases.Select(x => x.Id).ToList(),
                Identity = user.Email,
                Email = user.Email
            };
            #endregion

            #region Create Claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _settings.Issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("AllowedUseCases", JsonConvert.SerializeObject(actor.AllowedUseCaseIds)),
                new Claim("ForbiddenUseCases", JsonConvert.SerializeObject(actor.ForbiddenUseCaseIds)),
                new Claim("AdditionalUseCases", JsonConvert.SerializeObject(actor.AdditionalUseCaseIds)),
                new Claim("Email", user.Email)
            };
            #endregion

            #region Create Symmetric Security Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            #endregion

            #region Create Credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            #endregion

            #region Create Token
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_settings.Minutes),
                signingCredentials: credentials
            );
            #endregion

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
