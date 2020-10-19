using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IUserData
    {
        void DeleteUser(string userId);
        List<UserModel> GetUserById(string id);
        List<UserModel> GetUsers();
        void UpdateUser(UserModel user);
    }
}