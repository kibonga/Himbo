using FluentValidation;
using Himbo.Application.Exceptions;
using Himbo.Application.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Himbo.Api.Core.Common
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionLogger _logger;

        public GlobalExceptionHandler(RequestDelegate next, IExceptionLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            #region Global Try/Catch block
            try
            {
                // HttpContext contains info about HTTP request
                await _next(httpContext); // Passes httpContext to next handler
            }
            catch (Exception ex)
            {
                #region Log Exception
                _logger.Log(ex);
                #endregion

                #region Set Response Headers
                httpContext.Response.ContentType = "application/json";
                #endregion

                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                #region Unauthorized
                if (ex is AuthenticationFailedException authEx)
                {
                    statusCode = StatusCodes.Status401Unauthorized;
                    response = new
                    {
                        message = authEx.Message
                    };
                }
                #endregion

                #region Check if Forbidden
                if (ex is ForbiddenUseCaseExecutionException)
                {
                    statusCode = StatusCodes.Status403Forbidden;
                }
                #endregion

                #region Check if Not Found
                if (ex is EntityNotFoundException)
                {
                    statusCode = StatusCodes.Status404NotFound;
                }
                #endregion

                #region Check if Validation Error
                if (ex is ValidationException validationEx)
                {
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        errors = validationEx.Errors.Select(x => new
                        {
                            property = x.PropertyName,
                            error = x.ErrorMessage
                        })
                    };
                }
                #endregion

                #region Check if UseCase is Valid
                if (ex is UseCaseConflictException conflictEx)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new { message = conflictEx.Message };
                }
                #endregion

                httpContext.Response.StatusCode = statusCode;
                if (response != null)
                {
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
            #endregion
        }
    }
}
