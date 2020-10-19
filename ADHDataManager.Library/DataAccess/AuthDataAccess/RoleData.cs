using ADHDataManager.Library.Internal.DataAccess;
using System.Threading.Tasks;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public class RoleData : IRoleData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public RoleData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        // parameters will set in main class because role model is API model
        public async Task AddNewRole<T>(T parameters, string procedureName)
        {
            await _sqlDataAccess.SaveTaskData<T>(procedureName, parameters);
        }

        public async Task<T> FindRoleByID<T, U>(U parameters, string procedureName)
        {
            return await _sqlDataAccess.LoadTaskData<T, dynamic>(procedureName, parameters);
        }

        public async Task<T> FindRoleByName<T, U>(U parameters, string procedureName)
        {
            return await _sqlDataAccess.LoadTaskData<T, dynamic>(procedureName, parameters);

        }
    }
}
