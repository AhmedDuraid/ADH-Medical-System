using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/staffAndPatients/[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackData feedbackData;

        public FeedbackController(IConfiguration configuration)
        {
            feedbackData = new FeedbackData(configuration);
        }

        // GET: api/staffAndPatients/Feedback/GetFeedbacks
        [HttpGet]
        public IActionResult GetFeedbacks()
        {

            var feedbacks = feedbackData.GetFeedbacks();

            return Ok(feedbacks);


        }

        // GET: api/staffAndPatients/Feedback/GetFeedbacksBotReaded
        [HttpGet]
        public List<FeedbackModel> GetFeedbacksBotReaded()
        {
            var Feedback = feedbackData.GetFeedbackByNotReaded();

            return Feedback;
        }

        // GET: api/staffAndPatients/Feedback/GetFeedbackReaderID/id
        [HttpGet("{readerId}")]
        public List<FeedbackModel> GetFeedbackReaderID(string readerId)
        {
            var Feedback = feedbackData.GetFeedbackByReaderId(readerId);

            return Feedback;
        }

        // POST: api/staffAndPatients/Feedback/AddFeedback/id
        [HttpPost]
        public void AddFeedback([FromBody] FeedbackModel feedback)
        {
            feedbackData.AddNewFeedback(feedback);

        }

        // POST: api/staffAndPatients/Feedback/UpdateFeedback/id
        [HttpPut]
        public IActionResult UpdateFeedback([FromBody] string readerId, string feedbackId)
        {
            feedbackData.UpdateFeedbackToReaded(readerId, feedbackId);

            return Ok();
        }
    }
}
