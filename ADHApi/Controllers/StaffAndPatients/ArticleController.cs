using ADHApi.Error;
using ADHApi.Helpers;
using ADHApi.Models.Articles;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleData _articleData;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly IUserData _userData;
        private readonly IUserClaims _userClaims;

        public ArticleController(IArticleData articleData, IApiErrorHandler apiErrorHandler, IUserData userData,
            IUserClaims userClaims)
        {
            _articleData = articleData;
            _apiErrorHandler = apiErrorHandler;
            _userData = userData;
            _userClaims = userClaims;
            ;
        }

        // GET: api/ArticleController/Admin
        [HttpGet]
        [Authorize(Roles = "Admin, Doctor")]
        public IActionResult GetArticles()
        {
            try
            {
                string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                List<ArticleModel> articles = _articleData.FindArticlesByUserId(UserId);

                if (articles.Count > 0)
                {
                    return Ok(articles);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/Article/Staff
        [HttpPost("Staff")]
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNewArticle([FromBody] ApiAddArticleModel userInput)
        {
            try
            {
                ArticleModel Article = new()
                {
                    Titel = userInput.Titel,
                    Body = userInput.Body,
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    Show = userInput.Show
                };

                _articleData.AddArticle(Article);

                return Ok($"article {Article.UserId} created");
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
        public IActionResult UpdateArticle(string id, [FromBody] ApiAddArticleModel model)
        {
            try
            {
                string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var article = _articleData.FindArticleByID(UserId);

                if (article[0].UserId != UserId)
                {
                    return StatusCode(405);
                }

                ArticleModel Article = new()
                {
                    Body = model.Body,
                    Titel = model.Titel,
                    Show = model.Show,
                    Id = id,
                    UserId = UserId
                };

                _articleData.UpdateArticle(Article);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE api/Article/Staff
        [HttpDelete("Staff/{articleId}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult Delete(string articleId)
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
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
