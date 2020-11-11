using System.Collections.Generic;
using System.Threading.Tasks;
using UIDataAccess.Library.Models;
using UIDataAccess.Library.Models.Admin;

namespace UIDataAccess.Library.DataAccess.Admin
{
    public interface IUsersDataAccess
    {
        Task<(List<UserModle>, HttpInfoModel)> GetUsers(string token);
        Task<HttpInfoModel> RegisterUser<T>(string token, T registerInfo);
    }
}