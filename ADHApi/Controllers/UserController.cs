using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/User
        [HttpGet]
        public List<UserModel> GetUsers()
        {
            UserData userData = new UserData();


            // return userData.GetUsers();
            throw new NotImplementedException();
        }


        // GET: api/User/5
        //[HttpGet("{id}")]
        //public List<UserModel> GetByID(int id)
        //{

        //    UserData data = new UserData(_configuration);

        //    return data.GetUserById(id);
        //}

        // // POST: api/User
        //[HttpPost]
        // public void Post([FromBody] UserModel user)
        // {
        //     UserData userData = new UserData(_configuration);

        //     userData.CreateUser(user);

        // }
    }
}
