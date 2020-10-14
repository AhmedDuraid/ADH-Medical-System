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
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly string _connectionString;
        private readonly UserData _userData;
        private readonly UserRoleData _userRoleData = new UserRoleData();

        public AccountController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration
          )

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userData = new UserData();
            _connectionString = configuration.GetConnectionString("AHDConnection");
        }


        [HttpPost("[action]")]
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
                    var RoleId = await _roleManager.FindByNameAsync("Manager");

                    var Parameters = new
                    {
                        @UserId = user.Id,
                        @RoleId = RoleId.Id
                    };

                    _userRoleData.SaveData<dynamic>(_connectionString
                        , "dbo.spUserRole_AddUserRole_Auth"
                        , Parameters);

                    return Ok("user created");
                }
                else
                {
                    return BadRequest(result.Errors);
                }

            }
            else
            {
                return BadRequest();
            }


        }

        [HttpPut("[action]/{id}")]
        public IActionResult UpdateUserInfo(string id, [FromBody] UserModel user)
        {
            if (ModelState.IsValid)
            {
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

            }





            return Ok(user);
        }



    }
}
