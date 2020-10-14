using ADHDataManager.Library.Internal.DataAccess;
using System.Threading.Tasks;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public class RoleData
    {
        private readonly SqlDataAccess sqlDataAccess = new SqlDataAccess();

        // parameters will set in main class because role model is API model
        public async Task AddNewRole<T>(string connectionString, T parameters, string procedureName)
        {
            await sqlDataAccess.SaveTaskData<T>(procedureName, parameters, connectionString);
        }

        public async Task<T> FindRoleByID<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await sqlDataAccess.LoadTaskData<T, dynamic>(procedureName, parameters, connectionString);
        }

        public async Task<T> FindRoleByName<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await sqlDataAccess.LoadTaskData<T, dynamic>(procedureName, parameters, connectionString);

        }
    }
}
