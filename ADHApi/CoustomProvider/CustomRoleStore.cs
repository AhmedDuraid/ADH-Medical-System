using ADHDataManager.Library.DataAccess.AuthDataAccess;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ADHApi.CoustomProvider
{
    public class CustomRoleStore : IRoleStore<ApplicationRole>
    {
        private readonly IRoleData _roleData;

        public CustomRoleStore(IRoleData roleData)
        {
            _roleData = roleData;

        }
        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Parameters = new { @RoleID = role.Id, @RoleName = role.Name, @NormalizedRoleName = role.NormalizedRoleName };

            await _roleData.AddNewRole<dynamic>(Parameters, "dbo.spRoles_AddNewRole_Auth");

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            _roleData.DeleteRole(role.Id);

            return IdentityResult.Success;
        }

        public void Dispose()
        {
            //
        }

        public async Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Parameters = new { @RoleID = roleId };

            var Role = await _roleData.FindRoleByID<ApplicationRole, dynamic>(Parameters, "dbo.spRoles_GetRoleByID_Auth");

            return Role;

        }

        public async Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Parameters = new { @NormalizedRoleName = normalizedRoleName };
            var Role = await _roleData.FindRoleByName<ApplicationRole, dynamic>(Parameters, "dbo.spRoles_GetRoleByName_Auth");

            return Role;
        }

        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.NormalizedRoleName = normalizedName);
        }

        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            //var Parameters = new
            //{
            //    @Name = role.Name,
            //    @NormalizedRoleName = role.NormalizedRoleName,
            //    @Id = role.Id
            //};
            //_roleData.UpdateRole(Parameters);

            //return IdentityResult.Success;
            throw new NotImplementedException();

        }
    }
}
