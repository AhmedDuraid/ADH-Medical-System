using System.Collections.Generic;
using System.Threading.Tasks;
using UIDataAccess.Library.Models;
using UIDataAccess.Library.Models.Admin;

namespace UIDataAccess.Library.DataAccess.Admin
{
    public interface IRoleDataAccess
    {
        Task<HttpInfoModel> AddRole(string token, string roleName);
        Task<HttpInfoModel> DeleteRole(string token, string roleId);
        Task<(List<RoleModle>, HttpInfoModel)> GetRoles(string token);
        Task<HttpInfoModel> UpdateRole(string token, RoleModle roleData);
    }
}