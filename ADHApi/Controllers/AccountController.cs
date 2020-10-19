using ADHApi.CoustomProvider;
using ADHApi.Models;
using ADHApi.Models.User;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.DataAccess.AuthDataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserData _userData;
        private readonly UserRoleData _userRoleData;

        public AccountController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration
          )

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRoleData = new UserRoleData(configuration);
            _userData = new UserData(configuration);
        }

        // POST: api/Account
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAccount([FromBody] RegisterModel model)
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
                    ApplicationRole RoleInfo = await _roleManager.FindByNameAsync(model.RoleType);

                    if (RoleInfo != null)
                    {
                        _userRoleData.AddUserToRole(user.Id, RoleInfo.Id);

                        return Ok($"user {user.UserName} created with {RoleInfo.Name} Role");
                    }

                    return NotFound($"User created, but there is no {model.RoleType} Role. Trt to Add {model.RoleType} and assign it to {model.UserName}");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return BadRequest("Not valid");
        }

        // PUT: api/Account
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateModel userInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var UserInfo = new UserModel()
            {
                Id = UserId,
                FirstName = userInput.FirstName,
                MiddleName = userInput.MiddleName,
                LastName = userInput.LastName,
                BirthDate = userInput.BirthDate,
                PhoneNumber = userInput.PhoneNumber,
                Gender = userInput.Gender,
                Nationality = userInput.Nationality,
                Address = userInput.Address
            };

            _userData.UpdateUser(UserInfo);

            return Ok($"{UserId} information Updated ");
        }

        // PUT: api/Account/Admin/{id}
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("Admin/{id}")]
        public IActionResult UpdateUser(string id, [FromBody] UserUpdateModel userInput)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            var UserInfo = new UserModel()
            {
                Id = id,
                FirstName = userInput.FirstName,
                MiddleName = userInput.MiddleName,
                LastName = userInput.LastName,
                BirthDate = userInput.BirthDate,
                PhoneNumber = userInput.PhoneNumber,
                Gender = userInput.Gender,
                Nationality = userInput.Nationality,
                Address = userInput.Address
            };

            _userData.UpdateUser(UserInfo);

            return Ok($"User {id} information Updated ");
        }

        // PUT: api/Account/Admin/{id}
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("Admin/{id}")]
        public IActionResult DeleteUser(string id)
        {
            _userData.DeleteUser(id);

            return Ok($"user {id} Deleted");
        }

    }
}
