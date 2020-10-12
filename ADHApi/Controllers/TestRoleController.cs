using ADHApi.CoustomProvider;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public TestRoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] ApplicationRole model)
        {
            IdentityResult s = await _roleManager.CreateAsync(model);
            return Ok(s);
        }
    }
}
