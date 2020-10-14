using ADHDataManager.Library.Internal.DataAccess;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public class UserRoleData
    {
        private readonly SqlDataAccess _sqlDataAccess = new SqlDataAccess();
        public List<T> LoadUserRoleByID<T, U>(string connectionString, U parameters, string procedureName)
        {

            var output = _sqlDataAccess.LoadData<T, U>(procedureName, parameters, connectionString);

            return output;

        }
        public void SaveData<T>(string connectionString, string procedureName, T parameters)
        {
            _sqlDataAccess.SaveData<T>(procedureName, parameters, connectionString);

        }
    }
}
