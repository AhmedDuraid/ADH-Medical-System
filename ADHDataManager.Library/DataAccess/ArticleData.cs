using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class ArticleData
    {
        private readonly string _connectionString;
        private readonly string _connectionName = "AHDConnection";
        private readonly SqlDataAccess _sqlDataAccess;

        public ArticleData(IConfiguration configuration)
        {

            _connectionString = configuration.GetConnectionString(_connectionName);
            _sqlDataAccess = new SqlDataAccess();

        }

        public List<ArticleModel> FindArticles(bool show)
        {
            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindAllArticles_show",
                new { @Show = show },
                 _connectionString);

            return output;
        }
        public List<ArticleModel> FindArticles()
        {
            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticles_staff",
                 new { },
                  _connectionString);

            return output;
        }

        public List<ArticleModel> FindArticleByID(string id, bool show)
        {
            var Parameters = new { @ArticleId = id, @Show = show };

            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticlesById_shown", Parameters,
                 _connectionString);

            return output;

        }

        public List<ArticleModel> FindArticlesByUserName(string userName, bool show)
        {
            var Parameters = new { @UserName = userName, @Show = show };

            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticlesByUsername_shown", Parameters,
                 _connectionString);

            return output;

        }


        public List<ArticleModel> FindArticlesByUserId(string userId)
        {
            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindAreticlesByUserID_staff",
                new { @UserId = userId },
                 _connectionString);

            return output;
        }

        public void AddArticle(ArticleModel article)
        {
            var Parameters = new
            {
                @Id = article.Id,
                @Titel = article.Titel,
                @Body = article.Body,
                @UserId = article.UserId,
                @Show = article.Show,

            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spArticles_AddNewArticle", Parameters, _connectionString);
        }

        public void UpdateArticle(ArticleModel model)
        {
            var Parameters = new
            {
                @ArticleId = model.Id,
                @Titel = model.Titel,
                @Body = model.Body,
                @Show = model.Show,
                @UserId = model.UserId
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spArticles_UpdateArticles", Parameters, _connectionString);
        }

        public void DeleteArticle(string articleId)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new
            {
                @ArticleId = articleId,

            };

            sqlDataAccess.SaveData<dynamic>("dbo.spArticles_DeleteArticle", Parameters, _connectionString);
        }
    }
}
