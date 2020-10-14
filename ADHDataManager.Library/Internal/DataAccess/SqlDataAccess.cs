using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADHDataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {


        public List<T> LoadData<T, U>(string procedureName, U procedureParameter, string connectionString)
        {


            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(
                    procedureName,
                    procedureParameter,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string procedureName, T procedureParameter, string connectionString)
        {

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(procedureName, procedureParameter,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task SaveTaskData<T>(string procedureName, T procedureParameter, string connectionString)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(procedureName,
                    procedureParameter
                    , commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<T> LoadTaskData<T, U>(string procedureName, U procedureParameter, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var rows = await connection.QuerySingleOrDefaultAsync<T>(procedureName,
                    procedureParameter,
                    commandType: CommandType.StoredProcedure);

                return rows;
            }
        }
    }
}

