using AuthDataAccess.Library.Internal.SqlDataAccess;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AuthDataAccess.Library.DataAccess
{
    public class UserRoleDataAccess
    {
        private readonly SqlDataAccess _sqlDataAccess;

        //public UserRoleDataAccess(SqlDataAccess sqlDataAccess)
        //{
        //    _sqlDataAccess = sqlDataAccess;
        //}

        public UserRoleDataAccess()
        {
            _sqlDataAccess = new SqlDataAccess();
        }

        public List<T> LoadUserRoleByID<T, U>(string connectionString, U parameters, string procedureName)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var rows = connection.Query<T>(procedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }
    }
}
