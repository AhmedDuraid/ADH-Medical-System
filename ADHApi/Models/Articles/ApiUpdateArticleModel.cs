namespace ADHApi.Models.Articles
{
    public class ApiUpdateArticleModel
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string Body { get; set; }
        public bool Show { get; set; }
    }
}
