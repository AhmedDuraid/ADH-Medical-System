using ADHDataManager.Library.Internal.DataAccess;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public class RoleData
    {
        private readonly SqlDataAccess sqlDataAccess;
        public RoleData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess(configuration);

        }

        // parameters will set in main class because role model is API model
        public async Task AddNewRole<T>(T parameters, string procedureName)
        {
            await sqlDataAccess.SaveTaskData<T>(procedureName, parameters);
        }

        public async Task<T> FindRoleByID<T, U>(U parameters, string procedureName)
        {
            return await sqlDataAccess.LoadTaskData<T, dynamic>(procedureName, parameters);
        }

        public async Task<T> FindRoleByName<T, U>(U parameters, string procedureName)
        {
            return await sqlDataAccess.LoadTaskData<T, dynamic>(procedureName, parameters);

        }
    }
}
