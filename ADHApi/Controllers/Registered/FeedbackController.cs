using ADHApi.Error;
using ADHDataManager.Library.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace ADHApi.Controllers.Registered
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

        // GET: api/Feedback
        [HttpGet("new")]
        [Authorize(Roles = "Manager")]
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

        // POST: api/Feedback
        [HttpPut]
        [Authorize(Roles = "Manager")]
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
