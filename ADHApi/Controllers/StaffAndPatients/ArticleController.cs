using ADHApi.CoustomProvider;
using ADHApi.Error;
using ADHApi.Models.Articles;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationRole> _userManager;

        public ArticleController(IArticleData articleData, IApiErrorHandler apiErrorHandler, UserManager<ApplicationRole> userManager)
        {
            _articleData = articleData;
            _apiErrorHandler = apiErrorHandler;
            _userManager = userManager;
        }

        // GET: api/ArticleController/Admin
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetArticles()
        {
            try
            {
                List<ArticleModel> articles = _articleData.FindArticles();

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

        // GET api/Article/{id}
        [HttpGet("Admin/{userId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetArticlesByUserId(string userId)
        {
            try
            {
                var user = _userManager.FindByIdAsync(userId);

                if (user.Result != null)
                {
                    List<ArticleModel> articles = _articleData.FindArticlesByUserId(userId);

                    if (articles.Count > 0)
                    {
                        return Ok(articles);
                    }

                    return NotFound();
                }

                return BadRequest($"No User with Id {userId}");

            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET api/ArticleController/Staff
        [HttpGet("Staff")]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetArticlesByUserId()
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                List<ArticleModel> articles = _articleData.FindArticlesByUserId(userId);

                if (articles == null)
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
                var Article = new ArticleModel()
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
        public IActionResult UpdateArticle(string id, [FromBody] ApiUpdateArticleModel model)
        {
            try
            {
                string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var article = _articleData.FindArticleByID(UserId);

                if (article[0].UserId != UserId)
                {
                    return StatusCode(405);
                }

                var Article = new ArticleModel()
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
        [Authorize(Roles = "Admin, Manager, Doctor")]
        public IActionResult Delete(string articleId)
        {
            try
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var UserRole = User.FindFirst(ClaimTypes.Role)?.Value;
                var article = _articleData.FindArticleByID(articleId);

                if (article == null)
                {
                    return BadRequest($"There is no Article with this Id {articleId} ");
                }

                // if he is admin, he can delete any article 
                if (UserRole == "Admin")
                {
                    _articleData.DeleteArticle(articleId);

                    return Ok();
                }

                // if he is not admin, he can delete only his articles
                if (article[0].UserId != UserId)
                {
                    return StatusCode(405);
                }

                _articleData.DeleteArticle(articleId);

                return Ok($"Artilce With Id = {articleId} Deleted");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);

            }

            return StatusCode(500);
        }

        // public 
        // GET: api/Article/public
        [HttpGet("public")]
        [AllowAnonymous]
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
                    ArticleList.Add(new PublicArticleModel
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
        [HttpGet("public/{id}")]
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
                    ArticleList.Add(new PublicArticleModel
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
        [HttpGet("public/user/{userName}")]
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

                List<PublicArticleModel> ArticleList = new List<PublicArticleModel>();

                foreach (var item in Result)
                {
                    var Article = new PublicArticleModel
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
