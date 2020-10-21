using ADHDataManager.Library.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ADHApi.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {

        private readonly IUserData _userData;

        public UsersController(IUserData userData)
        {
            _userData = userData;
        }

        // GET: api/UserController/Admin
        [HttpGet("Admin")]
        public IActionResult GetUsers()
        {
            var users = _userData.GetUsers();

            if (users.Count > 0)
            {
                return Ok(users);
            }

            return NotFound();
        }

        // GET api/<UserController>/Admin/{id}
        [HttpGet("Admin/{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _userData.GetUserById(id);

            if (user.Count > 0)
            {
                return Ok(user);
            }

            return NotFound();
        }

    }
}
