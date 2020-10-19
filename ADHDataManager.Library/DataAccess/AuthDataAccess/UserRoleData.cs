using ADHDataManager.Library.Internal.DataAccess;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public class UserRoleData
    {
        private readonly SqlDataAccess _sqlDataAccess;

        public UserRoleData(IConfiguration configuration)
        {
            _sqlDataAccess = new SqlDataAccess(configuration);
        }
        public List<T> LoadUserRoleByID<T, U>(string userId)
        {
            var Parameters = new { @UserId = userId };

            var output = _sqlDataAccess.LoadData<T, dynamic>("dbo.spUserRole_GetUserRoleById_Auth", Parameters);

            return output;

        }
        public void AddUserToRole(string userId, string roleId)
        {
            var Parameters = new { @UserId = userId, @RoleId = roleId };

            _sqlDataAccess.SaveData<dynamic>("dbo.spUserRole_AddUserRole_Auth", Parameters);

        }
    }
}
