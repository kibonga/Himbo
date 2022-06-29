using Dapper;
using Himbo.Application.UseCases;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Logging
{
    public class SpUseCaseLogger : IUseCaseLogger
    {
        private readonly string _connString;
        public SpUseCaseLogger(string connString)
        {
            _connString = connString;
        }

        public IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch search)
        {
            #region Create Connection
            var connection = GetSqlConnection();
            #endregion

            #region Stored Procedure
            return connection.Query<UseCaseLog>(
                    "GetUseCaseLogs",
                    new
                    {
                        dateFrom = search.DateFrom,
                        dateTo = search.DateTo,
                        user = search.Username,
                        useCaseName = search.UseCaseName,
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                );
            #endregion
        }

        public void Log(UseCaseLog log)
        {
            #region Create Connection
            var connection = GetSqlConnection();
            #endregion

            #region Stored Procedure
            connection.Query(
                    "AddNewLogRecord",
                    new
                    {
                        useCaseName = log.UseCaseName,
                        username = log.User,
                        userId = log.UserId,
                        executionTime = log.ExecutionDateTime,
                        data = log.Data,
                        isAuthorized = log.IsAuthorized
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                );
            #endregion
        }

        #region GetSqlConnection
        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connString);
        } 
        #endregion
    }
}
