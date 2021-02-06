using ADHApi.Error;
using ADHApi.Models.Articles;
using ADHDataManager.Library.DataAccess;
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

        // TODO:    Create Public Display Model

        public PublicController(IArticleData articleData, IApiErrorHandler apiErrorHandler)
        {
            _articleData = articleData;
            _apiErrorHandler = apiErrorHandler;
        }

        [HttpGet("Articles")]
        public IActionResult GetPublicArticles()
        {
            try
            {
                var Result = _articleData.FindArticles(true);

                if (Result == null)
                {
                    return NotFound();
                }

                List<PublicArticleModel> ArticleList = new List<PublicArticleModel>();

                foreach (var item in Result)
                {
                    ArticleList.Add(new()
                    {
                        Id = item.Id,
                        Titel = item.Titel,
                        Body = item.Body,
                        CreateDate = item.CreateDate,
                        LastUpdate = item.LastUpdate,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        UserName = item.UserName
                    });
                }

                return Ok(ArticleList);
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Article/public/{id}
        [HttpGet("Article/id/{id}")]
        [AllowAnonymous]
        public IActionResult GetAricleByID(string id)
        {
            try
            {
                var Result = _articleData.FindArticleByID(id, true);

                if (Result == null)
                {
                    return NotFound();
                }

                List<PublicArticleModel> ArticleList = new List<PublicArticleModel>();

                foreach (var item in Result)
                {
                    ArticleList.Add(new()
                    {
                        Id = item.Id,
                        Titel = item.Titel,
                        Body = item.Body,
                        CreateDate = item.CreateDate,
                        LastUpdate = item.LastUpdate,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        UserName = item.UserName
                    });
                }

                return Ok(ArticleList);
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Article/public/{id}
        [HttpGet("Article/userId/{userName}")]
        [AllowAnonymous]
        public IActionResult GetAricleByUserName(string userName)
        {
            try
            {
                var Result = _articleData.FindArticlesByUserName(userName, true);

                if (Result == null)
                {
                    return NotFound();
                }

                List<PublicArticleModel> ArticleList = new();

                foreach (var item in Result)
                {
                    PublicArticleModel Article = new()
                    {
                        Id = item.Id,
                        Titel = item.Titel,
                        Body = item.Body,
                        CreateDate = item.CreateDate,
                        LastUpdate = item.LastUpdate,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        UserName = item.UserName
                    };
                    ArticleList.Add(Article);
                }

                return Ok(ArticleList);
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }
    }
}
