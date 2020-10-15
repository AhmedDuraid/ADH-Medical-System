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
        private readonly string connectionName = "AHDConnection";
        private readonly ArticleData articles;
        private readonly IConfiguration _configuration;

        public ArticleController(IConfiguration configuration)
        {
            //  _connectionString = configuration.GetConnectionString("AHDConnection");
            _configuration = configuration;
            articles = new ArticleData(configuration, connectionName);
        }

        // GET: api/Article/Get
        [HttpGet]
        public List<ArticleModel> GetArticles()
        {

            var Result = articles.FindArticles_Public(true);

            return Result;
        }

        // GET: api/Article/GetAricleByID/{id}
        [HttpGet("{id}")]
        public List<ArticleModel> GetAricleByID(string id)
        {

            var Result = articles.FindArticleByID_Public(id, true);

            return Result;
        }

        // GET: api/Article/GetAricleByUserName/{id}
        [HttpGet("{userName}")]
        public List<ArticleModel> GetAricleByUserName(string userName)
        {

            var Result = articles.FindArticlesByUserId_Public(userName, true);

            return Result;
        }


    }
}
