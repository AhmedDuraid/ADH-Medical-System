using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class ArticleData
    {
        private readonly string ConnectionName = "AHDConnection";
        private readonly IConfiguration _configuration;

        public ArticleData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ArticleModel> GetArticles()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_GetAllArticles", new { },
                 ConnectionName);

            return output;
        }

        public List<ArticleModel> GetArticleByID(int id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var Parameters = new { @ID = id };

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_GetArticleByID", Parameters,
                 ConnectionName);

            return output;

        }

        public void AddArticle(ArticleModel article)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var Parameters = new
            {
                @ArticalTitel = article.article_titel,
                @ArticleBody = article.article_body,
                @UserId = article.user_id
            };

            sqlDataAccess.SaveData<dynamic>("dbo.sp_Articles_CreateArticle", Parameters, ConnectionName);

        }
    }
}
