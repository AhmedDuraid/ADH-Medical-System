using ADHApi.Error;
using ADHApi.Models.Feedback;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackData _feedbackData;
        private readonly IApiErrorHandler _apiErrorHandler;

        public FeedbackController(IFeedbackData feedbackData, IApiErrorHandler apiErrorHandler)
        {
            _feedbackData = feedbackData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/Feedback/
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetFeedbacks()
        {
            try
            {
                var feedbacks = _feedbackData.GetFeedbacks();

                if (feedbacks.Count > 0)
                {
                    return Ok(feedbacks);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Feedback
        [HttpGet("NotReaded")]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult GetFeedbacksNotReaded()
        {
            try
            {
                var Feedback = _feedbackData.GetFeedbackByNotReaded();

                if (Feedback.Count > 0)
                {
                    return Ok(Feedback);

                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Feedback
        [HttpGet("GetById")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetFeedbackReaderID()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var Feedback = _feedbackData.GetFeedbackByReaderId(userId);

                if (Feedback.Count > 0)
                {
                    return Ok(Feedback);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Feedback/readerId
        [HttpGet("Admin/{readerId}")]
        public IActionResult GetFeedbackReaderID(string readerId)
        {
            try
            {
                var Feedback = _feedbackData.GetFeedbackByReaderId(readerId);

                if (Feedback.Count > 0)
                {
                    return Ok(Feedback);

                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/Feedback
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddFeedback([FromBody] ApiCreateFeedbackModel feedbackInput)
        {
            try
            {
                FeedbackModel Feedback = new()
                {
                    Titel = feedbackInput.Titel,
                    Name = feedbackInput.Name,
                    Email = feedbackInput.Email,
                    Phone = feedbackInput.Phone,
                    FeedbackBody = feedbackInput.FeedbackBody
                };

                _feedbackData.AddNewFeedback(Feedback);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/Feedback
        [HttpPut]
        [Authorize(Roles = "Manager, Admin")]
        public IActionResult UpdateFeedback([FromQuery] string feedbackId)
        {
            try
            {
                var readerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _feedbackData.UpdateFeedbackToReaded(readerId, feedbackId);

                return Ok("Updated");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }
    }
}
