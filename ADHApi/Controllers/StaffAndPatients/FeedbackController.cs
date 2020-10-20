using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackData _feedbackData;

        public FeedbackController(IFeedbackData feedbackData)
        {
            _feedbackData = feedbackData;
        }

        // GET: api/Feedback/
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetFeedbacks()
        {
            var feedbacks = _feedbackData.GetFeedbacks();

            if (feedbacks.Count > 0)
            {
                return Ok(feedbacks);
            }

            return NotFound();
        }

        // GET: api/Feedback
        [HttpGet("NotReaded")]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult GetFeedbacksNotReaded()
        {
            var Feedback = _feedbackData.GetFeedbackByNotReaded();

            if (Feedback.Count > 0)
            {
                return Ok(Feedback);

            }

            return NotFound();
        }

        // GET: api/Feedback
        [HttpGet("GetById")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetFeedbackReaderID()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Feedback = _feedbackData.GetFeedbackByReaderId(userId);

            if (Feedback.Count > 0)
            {
                return Ok(Feedback);
            }

            return NotFound();
        }

        // GET: api/Feedback/readerId
        [HttpGet("Admin/{readerId}")]
        public IActionResult GetFeedbackReaderID(string readerId)
        {
            var Feedback = _feedbackData.GetFeedbackByReaderId(readerId);

            if (Feedback.Count > 0)
            {
                return Ok(Feedback);

            }

            return NotFound();
        }

        // POST: api/Feedback
        [HttpPost]
        [AllowAnonymous]
        public void AddFeedback([FromBody] FeedbackModel feedback)
        {
            _feedbackData.AddNewFeedback(feedback);
        }

        // POST: api/Feedback
        [HttpPut]
        [Authorize(Roles = "Manager, Admin")]
        public IActionResult UpdateFeedback([FromQuery] string feedbackId)
        {
            var readerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _feedbackData.UpdateFeedbackToReaded(readerId, feedbackId);

            return Ok("Updated");
        }
    }
}
