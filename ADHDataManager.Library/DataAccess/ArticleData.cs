using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class ArticleData
    {
        private readonly string _connectionString;

        public ArticleData(IConfiguration configuration, string connectionName)
        {

            _connectionString = configuration.GetConnectionString(connectionName);

        }

        public List<ArticleModel> FindArticles_Public(bool show)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindAllArticles_show",
                new { @Show = show },
                 _connectionString);

            return output;
        }

        public List<ArticleModel> FindArticleByID_Public(string id, bool show)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new { @ArticleId = id, @Show = show };

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticlesById_shown", Parameters,
                 _connectionString);

            return output;

        }

        public List<ArticleModel> FindArticlesByUserId_Public(string userName, bool show)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new { @UserName = userName, @Show = show };

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticlesByUsername_shown", Parameters,
                 _connectionString);

            return output;

        }
        public List<ArticleModel> FindArticles_staff()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticles_staff",
                new { },
                 _connectionString);

            return output;
        }

        public List<ArticleModel> FindArticlesByUserId_staff(string userId)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindAreticlesByUserID_staff",
                new { @UserId = userId },
                 _connectionString);

            return output;
        }

        public void AddArticle_staff(ArticleModel article)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new
            {
                @Id = article.Id,
                @Titel = article.Titel,
                @Body = article.Body,
                @UserId = article.UserId,
                @Show = article.Show
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spArticles_AddNewArticle", Parameters, _connectionString);
        }

        public void UpdateArticle_staff(ArticleModel article, string articleId)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new
            {
                @ArticleId = articleId,
                @Titel = article.Titel,
                @Body = article.Body,
                @Show = article.Show
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spArticles_UpdateArticles", Parameters, _connectionString);
        }

        public void DeleteArticle_staff(string articleId)
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
