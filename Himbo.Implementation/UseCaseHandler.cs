using Himbo.Application.Exceptions;
using Himbo.Application.Logging;
using Himbo.Application.UseCases;
using Himbo.Domain.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation
{
    public class UseCaseHandler
    {
        private readonly IApplicationUser _user;
        private readonly IExceptionLogger _logger;
        private readonly IUseCaseLogger _useCaseLogger;

        public UseCaseHandler
        (
            IApplicationUser user,
            IExceptionLogger logger,// Handles Exceptions, eg. ConsoleExceptionLogger   (implements abstraction :IExceptionLogger)
            IUseCaseLogger useCaseLogger // Handles UseCase (activities) eg. ConsoleUseCaseLogger   (implements abstraction :IUseCaseLogger)
        )
        {
            _user = user;
            _logger = logger;
            _useCaseLogger = useCaseLogger;
        }

        #region Commands
        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization<TRequest>(command, data); // ICommand implements IUseCase interface

                var stopwatch = new Stopwatch(); // Optional
                stopwatch.Start();

                command.Execute(data);

                stopwatch.Stop();
                Console.WriteLine($"{command.Name} finnished in {stopwatch.ElapsedMilliseconds}ms");

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        public void HandleCommand<Id, TRequest>(ICommand<Id, TRequest> command, Id id, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization<TRequest>(command, data); // ICommand implements IUseCase interface

                var stopwatch = new Stopwatch(); // Optional
                stopwatch.Start();

                command.Execute(id, data);

                stopwatch.Stop();
                Console.WriteLine($"{command.Name} finnished in {stopwatch.ElapsedMilliseconds}ms");

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }
        #endregion

        #region Queries
        public TResult HandleQuery<TRequest, TResult>(IQuery<TRequest, TResult> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization<TRequest>(query, data);

                var stopwatch = new Stopwatch(); // Optional
                stopwatch.Start();

                var response = query.Execute(data);

                stopwatch.Stop();
                Console.WriteLine($"{query.Name} finnished in {stopwatch.ElapsedMilliseconds}ms");

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        public TResult HandleQuery<Id, TRequest, TResult>(Id id, IQuery<Id, TRequest, TResult> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization<TRequest>(query, data);

                var stopwatch = new Stopwatch(); // Optional
                stopwatch.Start();

                var response = query.Execute(id, data);

                stopwatch.Stop();
                Console.WriteLine($"{query.Name} finnished in {stopwatch.ElapsedMilliseconds}ms");

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }
        #endregion

        #region Auth
        public void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            // We need to pass something that implements IUseCase interface (ICommand/IQuery)
            // eg. EfCreateCatrogryCommand
            // It has it's own use case Id/Name/Description
            var isAuth = 
                !_user.ForbiddenUseCaseIds.Contains(useCase.Id) && 
                (_user.AllowedUseCaseIds.Contains(useCase.Id) || 
                _user.AdditionalUseCaseIds.Contains(useCase.Id));

            var log = new UseCaseLog
            {
                User = _user.Identity, // Identity can be: Username, FirsName/LastName, Email...(any format)
                ExecutionDateTime = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                UserId = _user.Id,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = isAuth
            };

            // TODO: Uncomment this line
            _useCaseLogger.Log(log);

            if (!isAuth)
            {
                throw new ForbiddenUseCaseExecutionException(useCase.Name, _user.Identity);
            }
        } 
        #endregion
    }
}
