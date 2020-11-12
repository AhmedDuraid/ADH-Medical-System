using System;

namespace ADHUIServer.Models.Feedback
{
    public class FeedbackModel
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FeedbackBody { get; set; }
        public DateTime Date { get; set; }
        public bool HasBeenRead { get; set; }
        public string ReaderId { get; set; }
        public string ReaderFirstName { get; set; }
        public string ReaderLastName { get; set; }
    }
}
