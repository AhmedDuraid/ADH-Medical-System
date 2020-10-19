using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


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

        // GET: api/UserController/
        [HttpGet]
        public List<UserModel> GetUsers()
        {
            var users = _userData.GetUsers();

            return users;
        }

        // GET api/<UserController>/id
        [HttpGet("{id}")]
        public List<UserModel> GetUser(string id)
        {
            var user = _userData.GetUserById(id);

            return user;
        }

    }
}
