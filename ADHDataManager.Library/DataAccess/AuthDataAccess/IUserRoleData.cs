using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public interface IUserRoleData
    {
        void AddUserToRole(string userId, string roleId);
        List<T> LoadUserRoleByID<T, U>(string userId);
    }
}