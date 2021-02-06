using ADHApi.Error;
using ADHApi.Models;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace ADHApi.Controllers.Public
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PublicController : ControllerBase
    {
        private readonly IArticleData _articleData;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly IMapper _mapper;

        public PublicController(IArticleData articleData,
            IApiErrorHandler apiErrorHandler,
            IMapper mapper)
        {
            _articleData = articleData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
        }

        // GET: api/public/Article
        [HttpGet("Articles")]
        public IActionResult GetPublicArticles()
        {
            try
            {
                List<ArticleModel> Result = _articleData.FindArticles(true);

                if (Result.Count > 0)
                {
                    var model = _mapper.Map<List<PublicArticleDisplayModel>>(Result);

                    return Ok(model);
                }

                return NotFound("There is no Articels");

            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/public/Article/id/{id}
        [HttpGet("Article/id/{id}")]
        [AllowAnonymous]
        public IActionResult GetAricleByID(string id)
        {
            try
            {
                var Result = _articleData.FindArticleByID(id, true);

                if (Result.Count > 0)
                {
                    var model = _mapper.Map<List<PublicArticleDisplayModel>>(Result);

                    return Ok(model);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/public/Article/userId/{id}
        [HttpGet("Article/userId/{userName}")]
        [AllowAnonymous]
        public IActionResult GetAricleByUserName(string userName)
        {
            try
            {
                var Result = _articleData.FindArticlesByUserName(userName, true);

                if (Result.Count > 0)
                {
                    var model = _mapper.Map<List<PublicArticleDisplayModel>>(Result);

                    return Ok(model);
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
