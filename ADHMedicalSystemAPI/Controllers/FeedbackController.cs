using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Feedbacks")]
    public class FeedbackController : ApiController
    {
        // GET: api/Feedback
        public List<FeedbackModel> Get()
        {
            FeedbackData data = new FeedbackData();
            var feedbacks = data.GetFeedbacks();

            return feedbacks;


        }
        public List<FeedbackModel> GetFeedbackById(int id)
        {
            FeedbackData data = new FeedbackData();

            var Feedback = data.GetFeedbackByID(id);

            return Feedback;
        }
        public void AddFeedback([FromBody] FeedbackModel feedback)
        {
            FeedbackData data = new FeedbackData();
            data.AddFeedback(feedback);

        }


    }
}
