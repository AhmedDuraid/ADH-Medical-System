using ADHApi.CoustomProvider;
using ADHApi.Error;
using ADHDataManager.Library.DataAccess.AuthDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IApiErrorHandler _apiErrorHandler;

        public RoleController(RoleManager<ApplicationRole> roleManager,
            IRoleData roleData,
            IApiErrorHandler apiErrorHandler)
        {
            _roleManager = roleManager;
            _roleData = roleData;
            _apiErrorHandler = apiErrorHandler;
        }
        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult GetRoles()
        {
            try
            {
                var roles = _roleData.FindRoles<ApplicationRole>();

                if (roles != null)
                {
                    return Ok(roles);
                }

                return NotFound();

            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);

            }

            return StatusCode(500);
        }

        // POST api/<RoleController>
        [HttpPost("{roleName}")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            try
            {
                if (roleName == null)
                {
                    return BadRequest();
                }

                var Role = new ApplicationRole() { Name = roleName };
                IdentityResult result = await _roleManager.CreateAsync(Role);

                if (result.Succeeded)
                {
                    return Ok($"Role {Role.Name} Added");
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT api/<RoleController>
        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] ApplicationRole applicationRole)
        {
            try
            {
                var searchResult = await _roleManager.FindByIdAsync(applicationRole.Id);

                if (searchResult == null)
                {
                    return NotFound($"There is no Role with this ID {applicationRole.Id}");
                }

                await _roleManager.UpdateNormalizedRoleNameAsync(applicationRole);

                var updatedRole = new ApplicationRole()
                {
                    Id = applicationRole.Id,
                    Name = applicationRole.Name,
                    NormalizedRoleName = applicationRole.NormalizedRoleName
                };

                _roleData.UpdateRole(updatedRole.Id, updatedRole.Name, updatedRole.NormalizedRoleName);

                return Ok($"Role {searchResult.Name} updated to {updatedRole.Name}");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(string id)
        {
            try
            {
                var FindRole = _roleManager.FindByIdAsync(id);

                if (FindRole.Result != null)
                {
                    var role = new ApplicationRole() { Id = id };
                    var Result = _roleManager.DeleteAsync(role);

                    if (Result.Result.Succeeded)
                    {
                        return Ok("Role Deleted");
                    }

                }

                return BadRequest($"There is no Role with Id= {id}");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);

            }

            return StatusCode(500);
        }
    }
}
