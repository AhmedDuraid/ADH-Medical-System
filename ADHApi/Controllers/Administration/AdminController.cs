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
    public class AdminController : ControllerBase
    {
        private readonly IArticleData _articleData;
        private readonly IApiErrorHandler _apiErrorHandler;

        public AdminController(IArticleData articleData, IApiErrorHandler apiErrorHandler)
        {
            _articleData = articleData;
            _apiErrorHandler = apiErrorHandler;
        }

        [HttpGet("Articles")]
        public IActionResult GetArticles()
        {
            try
            {
                List<ArticleModel> articles = _articleData.FindArticles();

                if (articles.Count > 0)
                {
                    return Ok(articles);
                }
                else
                {
                    return NotFound("There is no Articles to show");
                }
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }
            return StatusCode(500);
        }

        // GET api/Admin/Article/{id}
        [HttpGet("Article/{userId}")]
        public IActionResult GetArticlesByUserId(string userId)
        {
            try
            {
                List<ArticleModel> articles = _articleData.FindArticlesByUserId(userId);

                if (articles.Count > 0)
                {
                    return Ok(articles);
                }

                return NotFound($"There is no Article with ID ${userId}");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE api/Admin/Article/{articleId}
        [HttpDelete("Article/{articleId}")]
        public IActionResult Delete(string articleId)
        {
            try
            {
                var article = _articleData.FindArticleByID(articleId);

                if (article.Count > 0)
                {
                    return NotFound($"There is no Article with this Id {articleId} ");
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
