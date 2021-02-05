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
        // TODO change Get methodes from 3 different methods to one 

        // TODO need to change to get user role, because user can have more than one User.FindVirst only get the first role that it find. all controllers need to be changed

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
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<ArticleModel> articles;

            var UserRoles = _userClaims.GetUserRole(User.Claims);

            try
            {
                foreach (var role in UserRoles)
                {
                    if (role == "Admin")
                    {
                        articles = _articleData.FindArticles();

                        if (articles.Count > 0)
                        {
                            return Ok(articles);
                        }

                        return NotFound("There is no Articles to show");
                    }
                    if (role == "Doctor")
                    {
                        articles = _articleData.FindArticlesByUserId(UserId);

                        if (articles.Count > 0)
                        {
                            return Ok(articles);
                        }

                        return NotFound();
                    }

                }

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
                List<ArticleModel> articles = _articleData.FindArticlesByUserId(userId);

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
        [Authorize(Roles = "Admin, Manager, Doctor")]
        public IActionResult Delete(string articleId)
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            List<string> UserRoles = _userClaims.GetUserRole(User.Claims);


            try
            {
                var article = _articleData.FindArticleByID(articleId);

                if (article == null)
                {
                    return BadRequest($"There is no Article with this Id {articleId} ");
                }

                foreach (var role in UserRoles)
                {
                    // if he is admin, he can delete any article 
                    if (role == "Admin")
                    {
                        _articleData.DeleteArticle(articleId);

                        return Ok();
                    }
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
