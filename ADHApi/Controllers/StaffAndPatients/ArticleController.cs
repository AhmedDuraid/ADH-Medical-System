using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/staffAndpatients/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly string connectionName = "AHDConnection";
        private readonly ArticleData articlesData;

        public ArticleController(IConfiguration configuration)
        {
            articlesData = new ArticleData(configuration, connectionName);
        }
        // GET: api/<ArticleController>/GetArticles
        [HttpGet]
        public IActionResult GetArticles()
        {
            List<ArticleModel> articles = articlesData.FindArticles_staff();

            return Ok(articles);
        }

        // GET api/<ArticleController>/GetArticlesByUserId/id
        [HttpGet("{userId}")]
        public IActionResult GetArticlesByUserId(string userId)
        {
            List<ArticleModel> articles = articlesData.FindArticlesByUserId_staff(userId);

            return Ok(articles);
        }

        // POST: api/Article/AddNewArticle
        [HttpPost]
        public IActionResult AddNewArticle([FromBody] ArticleModel values)
        {
            articlesData.AddArticle_staff(values);

            return Ok("article created");
        }

        // PUT api/<ArticleController>/UpdateArticle/
        [HttpPut("{articleId}")]
        public IActionResult UpdateArticle(string articleId, [FromBody] ArticleModel article)
        {
            articlesData.UpdateArticle_staff(article, articleId);

            return Ok();
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{articleId}")]
        public IActionResult Delete(string articleId)
        {
            articlesData.DeleteArticle_staff(articleId);

            return Ok();
        }


    }
}
