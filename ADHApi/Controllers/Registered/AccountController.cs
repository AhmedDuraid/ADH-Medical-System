using ADHApi.Error;
using ADHApi.ViewModels;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace ADHApi.Controllers.Registered
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IUserData _userData;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly IMapper _mapper;

        public AccountController(IUserData userData,
            IApiErrorHandler apiErrorHandler,
            IMapper mapper
          )

        {
            _userData = userData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
        }

        // PUT: api/Account
        [HttpPut]
        public IActionResult UpdateUser([FromBody] AccountViewModel userInput)
        {
            try
            {
                //TODO before update, check if the user update his information only 
                //TODO Cheeck if he is in the database before 

                string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var model = _mapper.Map<UserModel>(userInput);
                model.Id = UserId;

                _userData.UpdateUser(model);

                return Ok($"{UserId} information Updated ");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }
    }
}
