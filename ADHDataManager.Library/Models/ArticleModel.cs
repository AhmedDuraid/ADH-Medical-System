using System;

namespace ADHDataManager.Library.Models
{
    public class ArticleModel
    {
        public int article_id { get; set; }
        public string article_titel { get; set; }
        public string article_body { get; set; }
        public DateTime created_date { get; set; }
        public DateTime last_update { get; set; }
        public bool show { get; set; }
        public int user_id { get; set; }
    }
}
