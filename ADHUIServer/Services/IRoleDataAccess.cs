using ADHUIServer.Models;
using ADHUIServer.Models.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADHUIServer.Services
{
    public interface IRoleDataAccess
    {
        Task<HttpInfoModel> AddRole(string token, string roleName);
        Task<HttpInfoModel> DeleteRole(string token, string roleId);
        Task<(List<RoleModel>, HttpInfoModel)> GetRoles(string token);
        Task<HttpInfoModel> UpdateRole(string token, RoleModel roleData);
    }
}