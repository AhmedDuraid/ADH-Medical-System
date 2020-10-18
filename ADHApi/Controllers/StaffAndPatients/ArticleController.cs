using ADHApi.Models.Articles;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleData articlesData;

        public ArticleController(IConfiguration configuration)
        {
            articlesData = new ArticleData(configuration);
        }

        // GET: api/ArticleController/Admin
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetArticles()
        {
            List<ArticleModel> articles = articlesData.FindArticles();
            if (articles == null)
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
            List<ArticleModel> articles = articlesData.FindArticlesByUserId(userId);

            return Ok(articles);
        }

        // GET api/ArticleController/Staff
        [HttpGet("Staff")]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetArticlesByUserId()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<ArticleModel> articles = articlesData.FindArticlesByUserId(userId);

            if (articles == null)
            {
                return Ok(articles);
            }

            return NotFound();
        }

        // POST: api/Article/Staff
        [HttpPost("Staff")]
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNewArticle([FromBody] ArticleInterfaceModel userInput)
        {
            var Article = new ArticleModel()
            {
                Titel = userInput.Titel,
                Body = userInput.Body,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Show = userInput.Show
            };
            articlesData.AddArticle(Article);

            return Ok($"article {Article.UserId} created");
        }

        // PUT api/<ArticleController>/UpdateArticle/
        [HttpPut("{articleId}")]
        public IActionResult UpdateArticle(string articleId, [FromBody] ArticleInterfaceModel model)
        {
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Article = new ArticleModel()
            {
                Body = model.Body,
                Titel = model.Titel,
                Show = model.Show,
                Id = articleId,
                UserId = UserId
            };
            articlesData.UpdateArticle(Article);

            return Ok();
        }

        // DELETE api/Article/Staff
        [HttpDelete("Staff/{articleId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string articleId)
        {
            articlesData.DeleteArticle(articleId);

            return Ok();
        }

        // public 
        // GET: api/Article/public
        [HttpGet("public")]
        [AllowAnonymous]
        public IActionResult GetPublicArticles()
        {
            var Result = articlesData.FindArticles(true);
            if (Result != null)
            {
                return Ok(Result);
            }
            return NotFound();
        }
        // GET: api/Article/public/{id}
        [HttpGet("public/{id}")]
        [AllowAnonymous]
        public IActionResult GetAricleByID(string id)
        {

            var Result = articlesData.FindArticleByID(id, true);
            if (Result != null)
            {
                Ok(Result);

            }
            return NotFound();
        }

        // GET: api/Article/public/{id}
        [HttpGet("public/user/{userId}")]
        [AllowAnonymous]
        public IActionResult GetAricleByUserName(string userName)
        {
            var Result = articlesData.FindArticlesByUserName(userName, true);
            if (Result != null)
            {
                return Ok(Result);

            }
            return NotFound();
        }
    }
}
