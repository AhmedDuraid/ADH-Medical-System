namespace ADHApi.Models.Feedback
{
    public class ApiCreateFeedbackModel
    {
        public string Titel { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FeedbackBody { get; set; }
    }
}
