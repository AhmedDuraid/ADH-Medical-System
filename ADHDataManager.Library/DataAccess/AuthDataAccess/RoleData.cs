using ADHDataManager.Library.Internal.DataAccess;
using System.Collections.Generic;
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

        public List<T> FindRoles<T>()
        {
            return _sqlDataAccess.LoadData<T, dynamic>("dbo.spRoles_FindAll", new { });
        }

        public void UpdateRole(string id, string name, string nName)
        {
            var Parameters = new
            {
                @Name = name,
                @NormalizedRoleName = nName,
                @Id = id
            };
            _sqlDataAccess.SaveData<dynamic>("dbo.spRoles_UpdateRole", Parameters);

        }

        public void DeleteRole(string id)
        {
            _sqlDataAccess.SaveData<dynamic>("dbo.spRoles_DeleteRole", new { @Id = id });
        }
    }
}
