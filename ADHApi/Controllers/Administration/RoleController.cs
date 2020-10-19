using ADHApi.CoustomProvider;
using ADHDataManager.Library.DataAccess.AuthDataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ADHApi.Controllers.Administration
{
    [Route("api/[controller]/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {

        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IRoleData _roleData;

        public RoleController(RoleManager<ApplicationRole> roleManager, IRoleData roleData)
        {
            _roleManager = roleManager;
            _roleData = roleData;
        }
        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleData.FindRoles<ApplicationRole>();

            if (roles != null)
            {
                return Ok(roles);
            }
            return NotFound();
        }

        // POST api/<RoleController>
        [HttpPost("{roleName}")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            var Role = new ApplicationRole() { Name = roleName };
            IdentityResult result = await _roleManager.CreateAsync(Role);

            if (result.Succeeded)
            {
                return Ok(result);

            }

            return BadRequest(result.Errors);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] ApplicationRole applicationRole)
        {
            var searchResult = await _roleManager.FindByIdAsync(id);

            if (searchResult == null)
            {
                return NotFound($"There is no Role with this ID {id}");
            }

            await _roleManager.UpdateNormalizedRoleNameAsync(applicationRole);

            var updatedRole = new ApplicationRole()
            {
                Id = id,
                Name = applicationRole.Name,
                NormalizedRoleName = applicationRole.NormalizedRoleName
            };

            _roleData.UpdateRole(updatedRole.Id, updatedRole.Name, updatedRole.NormalizedRoleName);

            return Ok($"Role {searchResult.Name} updated to {updatedRole.Name}");
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(string id)
        {
            var role = new ApplicationRole() { Id = id };
            var Result = _roleManager.DeleteAsync(role);

            if (Result.Result.Succeeded)
            {
                return Ok("Role Deleted");

            }
            return BadRequest();


        }
    }
}
