using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers.Public
{
    [Route("api/public/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly ArticleData articles = new ArticleData();

        public ArticleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AHDConnection");
        }

        // GET: api/Article/Get
        [HttpGet]
        public List<ArticleModel> GetArticles()
        {

            var Result = articles.FindArticles_Public(_connectionString, true);

            return Result;
        }

        // GET: api/Article/GetAricleByID/{id}
        [HttpGet("{id}")]
        public List<ArticleModel> GetAricleByID(string id)
        {

            var Result = articles.FindArticleByID_Public(id, _connectionString, true);

            return Result;
        }

        // GET: api/Article/GetAricleByUserName/{id}
        [HttpGet("{userName}")]
        public List<ArticleModel> GetAricleByUserName(string userName)
        {

            var Result = articles.FindArticlesByUserId_Public(userName, _connectionString, true);

            return Result;
        }


    }
}
