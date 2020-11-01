using ADHApi.Error;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ADHApi.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {

        private readonly IUserData _userData;
        private readonly IApiErrorHandler _apiErrorHandler;

        public UsersController(IUserData userData, IApiErrorHandler apiErrorHandler)
        {
            _userData = userData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/UserController/Admin
        [HttpGet("Admin")]
        public IActionResult GetUsers()
        {
            try
            {
                List<UserModel> users = _userData.GetUsers();

                if (users.Count > 0)
                {
                    return Ok(users);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);

            }

            return StatusCode(500);

        }

        // GET api/<UserController>/Admin/{id}
        [HttpGet("Admin/{id}")]
        public IActionResult GetUser(string id)
        {
            try
            {
                var user = _userData.GetUserById(id);

                if (user.Count > 0)
                {
                    return Ok(user);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

    }
}
