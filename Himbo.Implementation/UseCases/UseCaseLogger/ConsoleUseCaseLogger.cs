using Himbo.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.UseCases.UseCaseLogger
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch search)
        {
            throw new NotImplementedException();
        }

        public void Log(UseCaseLog log)
        {
            Console.WriteLine($"UseCase: {log.UseCaseName}, User: {log.User}, {log.ExecutionDateTime}, Authorized: {log.IsAuthorized}");
            Console.WriteLine($"Use Case Data: {log.Data}");
        }
    }
}
