using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;


namespace ADHApi.Controllers.Administration
{
    [Route("api/admin/[controller]")]
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

        // POST api/<UserController>
        // handle in account cotroller



        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();

        }
    }
}
