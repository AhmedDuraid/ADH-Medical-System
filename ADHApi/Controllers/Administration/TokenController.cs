using ADHApi.CoustomProvider;
using ADHApi.Models;
using ADHDataManager.Library.DataAccess.AuthDataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ADHApi.Controllers.Administration
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRoleData _userRoleData;
        private readonly IConfiguration _configuration;

        public TokenController(UserManager<ApplicationUser> userManager, IUserRoleData userRoleData, IConfiguration configuration)
        {
            _userManager = userManager;
            _userRoleData = userRoleData;
            _configuration = configuration;
        }

        // GET: api/Token
        [HttpGet]
        public async Task<IActionResult> Create(string username, string password)
        {
            if (await IsValidUsernameAndPassword(username, password))
            {
                return new ObjectResult(await GenerateToken(username));
            }
            else
            {
                return NotFound();
            }
        }

        private async Task<bool> IsValidUsernameAndPassword(string username, string password)
        {
            // find if the user register and have password
            var user = await _userManager.FindByNameAsync(username);

            return await _userManager.CheckPasswordAsync(user, password);
        }

        // create token
        private async Task<dynamic> GenerateToken(string username)
        {
            // get user information 
            var user = await _userManager.FindByNameAsync(username);

            // get all this user roles to be added to the claim

            var roles = _userRoleData.LoadUserRoleByID<UserRoleModel, dynamic>(user.Id);

            var claims = new List<Claim> {

                new Claim(ClaimTypes.Name,username ),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
               new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };

            // adding user roles to the claim 
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));

            }


            string tokenPassword = _configuration.GetValue<string>("Secrets:SecurityKey");

            // create new token
            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenPassword)),
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            var output = new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = username
            };

            return output;
        }
    }
}
