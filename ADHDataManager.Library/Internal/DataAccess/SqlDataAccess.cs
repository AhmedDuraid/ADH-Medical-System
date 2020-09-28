using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ADHDataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        // the internal class that will connect to SQL server with dapper 
        public string GetConnectionString(string stringName)
        {
            return ConfigurationManager.ConnectionStrings[stringName].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameter, string connectionStringName)
        {
            // connection string will be from API web config 
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(
                    storedProcedure,
                    parameter,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameter, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameter,
                    commandType: CommandType.StoredProcedure);


            }
        }
    }
}

