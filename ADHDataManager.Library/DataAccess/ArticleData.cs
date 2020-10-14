using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class ArticleData
    {

        public List<ArticleModel> FindArticles_Public(string connectionString, bool show)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindAllArticles_show",
                new { @Show = show },
                 connectionString);

            return output;
        }

        public List<ArticleModel> FindArticleByID_Public(string id, string connectionString, bool show)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new { @ArticleId = id, @Show = show };

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticlesById_shown", Parameters,
                 connectionString);

            return output;

        }

        public List<ArticleModel> FindArticlesByUserId_Public(string userName, string connectionString, bool show)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new { @UserName = userName, @Show = show };

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticlesByUsername_shown", Parameters,
                 connectionString);

            return output;

        }
        public List<ArticleModel> FindArticles_staff(string connectionString)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticles_staff",
                new { },
                 connectionString);

            return output;
        }

        public List<ArticleModel> FindArticlesByUserId_staff(string userId, string connectionString)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindAreticlesByUserID_staff",
                new { @UserId = userId },
                 connectionString);

            return output;
        }

        public void AddArticle_staff(ArticleModel article, string connectionString)
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

            sqlDataAccess.SaveData<dynamic>("dbo.spArticles_AddNewArticle", Parameters, connectionString);
        }

        public void UpdateArticle_staff(ArticleModel article, string articleId, string connectionString)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new
            {
                @ArticleId = articleId,
                @Titel = article.Titel,
                @Body = article.Body,
                @Show = article.Show
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spArticles_UpdateArticles", Parameters, connectionString);
        }

        public void DeleteArticle_staff(string articleId, string connectionString)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new
            {
                @ArticleId = articleId,

            };

            sqlDataAccess.SaveData<dynamic>("dbo.spArticles_DeleteArticle", Parameters, connectionString);
        }
    }
}
