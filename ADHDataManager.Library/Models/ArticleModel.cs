using System;

namespace ADHDataManager.Library.Models
{
    public class ArticleModel
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Show { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
