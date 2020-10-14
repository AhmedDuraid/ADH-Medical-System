using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers.Staff
{
    [Route("api/staff/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly ArticleData articlesData = new ArticleData();

        public ArticleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AHDConnection");
        }
        // GET: api/<ArticleController>/GetArticles
        [HttpGet]
        public IActionResult GetArticles()
        {
            List<ArticleModel> articles = articlesData.FindArticles_staff(_connectionString);

            return Ok(articles);
        }

        // GET api/<ArticleController>/GetArticlesByUserId/id
        [HttpGet("{userId}")]
        public IActionResult GetArticlesByUserId(string userId)
        {
            List<ArticleModel> articles = articlesData.FindArticlesByUserId_staff(userId, _connectionString);

            return Ok(articles);
        }

        // POST: api/Article/AddNewArticle
        [HttpPost]
        public IActionResult AddNewArticle([FromBody] ArticleModel values)
        {
            articlesData.AddArticle_staff(values, _connectionString);

            return Ok("article created");
        }

        // PUT api/<ArticleController>/UpdateArticle/
        [HttpPut("{articleId}")]
        public IActionResult UpdateArticle(string articleId, [FromBody] ArticleModel article)
        {
            articlesData.UpdateArticle_staff(article, articleId, _connectionString);

            return Ok();
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{articleId}")]
        public IActionResult Delete(string articleId)
        {
            articlesData.DeleteArticle_staff(articleId, _connectionString);

            return Ok();
        }


    }
}
