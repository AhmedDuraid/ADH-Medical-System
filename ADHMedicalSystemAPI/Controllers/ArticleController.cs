using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Article")]
    public class ArticleController : ApiController
    {
        // GET: api/Article
        public List<ArticleModel> Get()
        {
            ArticleData articles = new ArticleData();
            var Result = articles.GetArticles();

            return Result;
        }
        // GET: api/Article/{id}
        public List<ArticleModel> GetAricleByID(int id)
        {
            ArticleData articles = new ArticleData();
            var Result = articles.GetArticleByID(id);

            return Result;
        }

        // POST: api/Article
        public void Post([FromBody] ArticleModel values)
        {

            ArticleData articles = new ArticleData();

            articles.AddArticle(values);


        }
    }
}
