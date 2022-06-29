using FluentValidation;
using Himbo.Application.UseCases;
using Himbo.Application.UseCases.Queries.UseCase;
using Himbo.Implementation.Validators.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.Queries.UseCase
{
    public class SpGetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly IUseCaseLogger _logger;
        private readonly SearchUseCaseLogsValidator _validator;

        #region UsesCase Data
        public int Id => 52;
        public string Name => "Query all UseCase Logs (SP)";
        public string Description => "Use case for querying all UseCase Logs using SP"; 
        #endregion

        public SpGetUseCaseLogsQuery(IUseCaseLogger logger, SearchUseCaseLogsValidator validator)
        {
            _logger = logger;
            _validator = validator;
        }
        public IEnumerable<UseCaseLog> Execute(UseCaseLogSearch search)
        {
            _validator.ValidateAndThrow(search);
            return _logger.GetLogs(search);
        }
    }
}
