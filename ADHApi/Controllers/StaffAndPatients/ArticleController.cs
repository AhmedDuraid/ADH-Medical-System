using ADHApi.Models.Articles;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public ArticleController(IArticleData articleData)
        {
            _articleData = articleData;
        }

        // GET: api/ArticleController/Admin
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetArticles()
        {
            List<ArticleModel> articles = _articleData.FindArticles();
            if (articles.Count > 0)
            {
                return Ok(articles);
            }
            return NotFound();
        }

        // GET api/Article/id
        [HttpGet("Admin/{userId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetArticlesByUserId(string userId)
        {
            List<ArticleModel> articles = _articleData.FindArticlesByUserId(userId);

            if (articles.Count > 0)
            {
                return Ok(articles);
            }

            return NotFound();

        }

        // GET api/ArticleController/Staff
        [HttpGet("Staff")]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetArticlesByUserId()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<ArticleModel> articles = _articleData.FindArticlesByUserId(userId);

            if (articles == null)
            {
                return Ok(articles);
            }

            return NotFound();
        }

        // POST: api/Article/Staff
        [HttpPost("Staff")]
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNewArticle([FromBody] ApiAddArticleModel userInput)
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

        // PUT api/<ArticleController>/UpdateArticle/
        [HttpPut]
        public IActionResult UpdateArticle([FromBody] ApiUpdateArticleModel model)
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
                Id = model.Id,
                UserId = UserId
            };
            _articleData.UpdateArticle(Article);

            return Ok();
        }

        // DELETE api/Article/Staff
        [HttpDelete("Staff/{articleId}")]
        [Authorize(Roles = "Admin, Manager, Doctor")]
        public IActionResult Delete(string articleId)
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var article = _articleData.FindArticleByID(UserId);

            if (article[0].UserId != UserId)
            {
                return StatusCode(405);
            }

            _articleData.DeleteArticle(articleId);

            return Ok();
        }

        // public 
        // GET: api/Article/public
        [HttpGet("public")]
        [AllowAnonymous]
        public IActionResult GetPublicArticles()
        {
            var Result = _articleData.FindArticles(true);
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

            if (Result != null)
            {

                return Ok(ArticleList);
            }
            return NotFound();
        }
        // GET: api/Article/public/{id}
        [HttpGet("public/{id}")]
        [AllowAnonymous]
        public IActionResult GetAricleByID(string id)
        {

            var Result = _articleData.FindArticleByID(id, true);
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
            if (Result != null)
            {
                return Ok(ArticleList);

            }
            return NotFound();
        }

        // GET: api/Article/public/{id}
        [HttpGet("public/user/{userName}")]
        [AllowAnonymous]
        public IActionResult GetAricleByUserName(string userName)
        {
            var Result = _articleData.FindArticlesByUserName(userName, true);
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

            if (Result != null)
            {
                return Ok(ArticleList);

            }
            return NotFound();
        }
    }
}
