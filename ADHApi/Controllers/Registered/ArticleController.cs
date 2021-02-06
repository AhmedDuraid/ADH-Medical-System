using ADHApi.Error;
using ADHApi.Models;
using ADHApi.ViewModels;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ADHApi.Controllers.Registered
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleData _articleData;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly IMapper _mapper;

        public ArticleController(IArticleData articleData,
            IApiErrorHandler apiErrorHandler,
            IMapper mapper)
        {
            _articleData = articleData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
        }

        // GET: api/Article
        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetArticles()
        {
            try
            {
                string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                List<ArticleModel> articles = _articleData.FindArticlesByUserId(UserId);

                var model = _mapper.Map<List<PrivateArticelDisplayModel>>(articles);

                if (articles.Count > 0)
                {
                    return Ok(model);
                }

                return NotFound("No Articels found");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/Article
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNewArticle([FromBody] ArticleViewModel userInput)
        {
            try
            {
                ArticleModel model = _mapper.Map<ArticleModel>(userInput);
                model.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _articleData.AddArticle(model);

                return Ok($"article {model.Id} created");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT api/<ArticleController>/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult UpdateArticle(string id, [FromBody] ArticleViewModel input)
        {
            try
            {
                string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var article = _articleData.FindArticleByID(UserId);

                if (article[0].UserId != UserId)
                {
                    return StatusCode(405);
                }

                var model = _mapper.Map<ArticleModel>(input);
                model.Id = id;
                model.UserId = UserId;

                _articleData.UpdateArticle(model);

                return Ok($"Article {model.Id} Updated");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE api/Article/Staff
        [HttpDelete("{articleId}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult Delete(string articleId)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var article = _articleData.FindArticleByID(articleId);

                if (article == null)
                {
                    return NotFound($"There is no Article with this Id {articleId} ");
                }

                // if he is not admin, he can delete only his articles
                if (article[0].UserId != UserId)
                {
                    return StatusCode(405);
                }
                else
                {
                    _articleData.DeleteArticle(articleId);

                    return Ok($"Artilce With Id = {articleId} Deleted");
                }

            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);

            }

            return StatusCode(500);
        }
    }
}
