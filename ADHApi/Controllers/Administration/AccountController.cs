using ADHApi.CoustomProvider;
using ADHApi.Models;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.DataAccess.AuthDataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ADHApi.Controllers.Administration
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly string _connectionString;
        private readonly UserData _userData = new UserData();
        private readonly UserRoleData _userRoleData = new UserRoleData();

        public AccountController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration
          )

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _connectionString = configuration.GetConnectionString("AHDConnection");
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Name = $"{model.FirstName} {model.LastName}"
                };

                // user create 
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // add user to role 
                    ApplicationRole RoleIdInfo = await _roleManager.FindByNameAsync(model.RoleType);

                    if (RoleIdInfo != null)
                    {
                        var Parameters = new
                        {
                            @UserId = user.Id,
                            @RoleId = RoleIdInfo.Id
                        };

                        _userRoleData.SaveData<dynamic>(_connectionString
                            , "dbo.spUserRole_AddUserRole_Auth"
                            , Parameters);

                        return Ok("user created");
                    }

                    return BadRequest();
                }
                else
                {
                    return BadRequest(result.Errors);
                }

            }
            else
            {
                return BadRequest("can not create user");
            }


        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserInfo(string id, [FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");

            }
            var newUserInfo = new
            {
                @UserId = id,
                @FirstName = user.FirstName,
                @MiddleName = user.MiddleName,
                @LastName = user.LastName,
                @BirthDate = user.BirthDate,
                @PhoneNumber = user.PhoneNumber,
                @Gender = user.Gender,
                @Nationality = user.Nationality,
                @Address = user.Address

            };
            _userData.UpdateUser(newUserInfo, _connectionString);

            return Ok("User Updated ");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            _userData.DeleteUser(id, _connectionString);

            return Ok("user Deleted");
        }

    }
}
