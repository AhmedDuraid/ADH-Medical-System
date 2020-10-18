﻿using ADHApi.CoustomProvider;
using ADHApi.Models;
using ADHApi.Models.User;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.DataAccess.AuthDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADHApi.Controllers
{
    [Route("api/[controller]/[action]")]
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

        // POST: api/Account/RegisterAccount
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

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _userData.UpdateUser(UserId, model.FirstName, model.MiddleName, model.LastName, model.BirthDate,
                model.PhoneNumber, model.Gender, model.Nationality, model.Address);

            return Ok($"{UserId} information Updated ");
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("admin/{id}")]
        public IActionResult UpdateUser(string id, [FromBody] UserUpdateModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            _userData.UpdateUser(id, model.FirstName, model.MiddleName,
                model.LastName, model.BirthDate, model.PhoneNumber, model.Gender, model.Nationality, model.Address);

            return Ok($"User {id} information Updated ");
        }


        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("admin/{id}")]
        public IActionResult DeleteUser(string id)
        {
            _userData.DeleteUser(id);

            return Ok($"user {id} Deleted");
        }

    }
}
