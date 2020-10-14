using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FeedbackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Feedback
        [HttpGet]
        public List<FeedbackModel> Get()
        {
            FeedbackData data = new FeedbackData();
            var feedbacks = data.GetFeedbacks();

            return feedbacks;


        }

        [HttpGet("{id}")]
        public List<FeedbackModel> GetFeedbackById(int id)
        {
            FeedbackData data = new FeedbackData();

            var Feedback = data.GetFeedbackByID(id);

            return Feedback;
        }

        [HttpPost]
        public void AddFeedback([FromBody] FeedbackModel feedback)
        {
            FeedbackData data = new FeedbackData();
            data.AddFeedback(feedback);

        }
    }
}
