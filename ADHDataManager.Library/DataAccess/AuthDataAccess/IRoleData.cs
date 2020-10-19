using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public interface IRoleData
    {
        Task AddNewRole<T>(T parameters, string procedureName);
        void DeleteRole(string id);
        Task<T> FindRoleByID<T, U>(U parameters, string procedureName);
        Task<T> FindRoleByName<T, U>(U parameters, string procedureName);
        List<T> FindRoles<T>();
        void UpdateRole(string id, string name, string nName);
    }
}