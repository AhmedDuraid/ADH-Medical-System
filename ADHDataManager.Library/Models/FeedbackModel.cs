using System;

namespace ADHDataManager.Library.Models
{
    public class FeedbackModel
    {
        public int feedback_id { get; set; }
        public string titel { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string feedback_body { get; set; }
        public DateTime date { get; set; }
        public bool has_been_read { get; set; }
        public DateTime update_date { get; set; }
    }
}
