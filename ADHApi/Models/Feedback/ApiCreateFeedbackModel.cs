using System.ComponentModel.DataAnnotations;

namespace ADHApi.Models.Feedback
{
    public class ApiCreateFeedbackModel
    {
        [Required]
        public string Titel { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string FeedbackBody { get; set; }
    }
}
