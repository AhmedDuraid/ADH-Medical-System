using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADHDataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        private readonly string _connectionName = "AHDConnection";
        private readonly string _connectionString;
        public SqlDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(_connectionName);

        }

        public List<T> LoadData<T, U>(string procedureName, U procedureParameter)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                List<T> rows = connection.Query<T>(
                    procedureName,
                    procedureParameter,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string procedureName, T procedureParameter)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(procedureName, procedureParameter,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task SaveTaskData<T>(string procedureName, T procedureParameter)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(procedureName,
                    procedureParameter
                    , commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<T> LoadTaskData<T, U>(string procedureName, U procedureParameter)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var rows = await connection.QuerySingleOrDefaultAsync<T>(procedureName,
                    procedureParameter,
                    commandType: CommandType.StoredProcedure);

                return rows;
            }
        }
    }
}

