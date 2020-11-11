using ADHUIServer.Models;
using ADHUIServer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADHUIServer.Services
{
    public interface IUsersDataAccess
    {
        Task<(List<UserModel>, HttpInfoModel)> GetUsers(string token);
        Task<HttpInfoModel> RegisterUser<T>(string token, T registerInfo);
    }
}