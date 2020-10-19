using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IArticleData
    {
        void AddArticle(ArticleModel article);
        void DeleteArticle(string articleId);
        List<ArticleModel> FindArticleByID(string id, bool show);
        List<ArticleModel> FindArticles();
        List<ArticleModel> FindArticles(bool show);
        List<ArticleModel> FindArticlesByUserId(string userId);
        List<ArticleModel> FindArticlesByUserName(string userName, bool show);
        void UpdateArticle(ArticleModel model);
    }
}