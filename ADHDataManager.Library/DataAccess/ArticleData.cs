using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class ArticleData : IArticleData
    {

        private readonly ISqlDataAccess _sqlDataAccess;

        public ArticleData(ISqlDataAccess sqlDataAccess)
        {

            _sqlDataAccess = sqlDataAccess;
        }

        public List<ArticleModel> FindArticles(bool show)
        {
            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindAllArticles_show", new { @Show = show });

            return output;
        }
        public List<ArticleModel> FindArticles()
        {
            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticles_staff", new { });

            return output;
        }

        public List<ArticleModel> FindArticleByID(string id, bool show)
        {
            var Parameters = new { @ArticleId = id, @Show = show };

            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticlesById_shown", Parameters);

            return output;

        }

        public List<ArticleModel> FindArticlesByUserName(string userName, bool show)
        {
            var Parameters = new { @UserName = userName, @Show = show };

            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindArticlesByUsername_shown", Parameters);

            return output;

        }


        public List<ArticleModel> FindArticlesByUserId(string userId)
        {
            var output = _sqlDataAccess.LoadData<ArticleModel, dynamic>("dbo.spArticles_FindAreticlesByUserID_staff", new { @UserId = userId });

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

            _sqlDataAccess.SaveData<dynamic>("dbo.spArticles_AddNewArticle", Parameters);
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

            _sqlDataAccess.SaveData<dynamic>("dbo.spArticles_UpdateArticles", Parameters);
        }

        public void DeleteArticle(string articleId)
        {
            var Parameters = new
            {
                @ArticleId = articleId,

            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spArticles_DeleteArticle", Parameters);
        }
    }
}
