using System;

namespace ADHApi.Models
{
    public class PublicArticleDisplayModel
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

    }
}
