using Dapper;
using LogsHandler.Library.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LogsHandler.Library.DataAccess
{
    public class LogsSqlDataAccess : ILogsSqlDataAccess
    {
        private readonly string _connectionName = "ADHLogs";
        private readonly string _connectionString;
        public LogsSqlDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(_connectionName);

        }

        public List<LogModel> LoadData()
        {
            var Parameters = new { };

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                List<LogModel> rows = connection.Query<LogModel>(
                    "dbo.spLog_FindAll",
                    Parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData(LogModel logModel)
        {
            var Parameters = new
            {
                @Message = logModel.Message,
                @StackTrace = logModel.StackTrace,
                @Source = logModel.Source,
            };

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute("dbo.spLog_AddNew", Parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
