using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Article
        [HttpGet]
        public List<ArticleModel> Get()
        {
            ArticleData articles = new ArticleData();
            var Result = articles.GetArticles();

            return Result;
        }

        // GET: api/Article/{id}
        [HttpGet("{id}")]
        public List<ArticleModel> GetAricleByID(int id)
        {
            ArticleData articles = new ArticleData();
            var Result = articles.GetArticleByID(id);

            return Result;
        }

        // POST: api/Article
        [HttpPost]
        public void Post([FromBody] ArticleModel values)
        {

            ArticleData articles = new ArticleData();

            articles.AddArticle(values);


        }
    }
}
