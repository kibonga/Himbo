using Himbo.Api.Core.Common;
using Himbo.Api.Core.Jwt;
using Himbo.Application.UseCases.Commands.Auth;
using Himbo.Application.UseCases.Commands.Tag;
using Himbo.DataAccess;
using Himbo.Domain.Common.Interfaces;
using Himbo.Implementation.UseCases.Commands.Auth;
using Himbo.Implementation.UseCases.Commands.Tag;
using Himbo.Implementation.Validators.Auth;
using Himbo.Implementation.Validators.Tag;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Himbo.Api.Extensions
{
    public static class ContainerExtensions
    {
        #region JWt
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            #region Register JwtManager
            services.AddTransient(x =>
            {
                var context = x.GetService<HimboDbContext>(); // TODO: Propably looks for a Service of type <HimboDbContext> which is services.AddHimboDbContext();
                var settings = x.GetService<AppSettings>(); // // TODO: Propably looks for a Service of type <AppSettings> which is services.AddSingleton(settings);

                return new JwtManager(context, settings.JwtSettings);
            });
            #endregion

            #region Register Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion
        }
        #endregion

        #region Application User
        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                #region Meta
                var accessor = x.GetService<IHttpContextAccessor>(); // TODO: Check what this line does
                var header = accessor.HttpContext.Request.Headers["Authorization"]; 
                #endregion

                #region User Claims
                var claims = accessor.HttpContext.User;
                #endregion

                #region Anonymous User
                if (claims is null || claims.FindFirst("UserId") is null)
                {
                    return new AnonymousUser();
                }
                #endregion

                #region Jwt User
                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    AllowedUseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("AllowedUseCases").Value),
                    AdditionalUseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("AdditionalUseCases").Value),
                    ForbiddenUseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("ForbiddenUseCases").Value)
                };
                #endregion

                return actor;

            });
        }
        #endregion

    }
}
