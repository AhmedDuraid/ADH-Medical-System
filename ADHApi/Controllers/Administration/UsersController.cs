using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace ADHApi.Controllers.Administration
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserData _userData;
        private readonly string _connectionString;

        public UsersController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AHDConnection");
            _userData = new UserData();
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<UserModel> GetUsers()
        {

            var users = _userData.GetUsers(_connectionString);

            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public List<UserModel> GetUser(string id)
        {
            var user = _userData.GetUserById(id, _connectionString);

            return user;
        }

    }
}
