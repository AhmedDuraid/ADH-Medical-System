using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IFeedbackData
    {
        void AddNewFeedback(FeedbackModel feedback);
        List<FeedbackModel> GetFeedbackByNotReaded();
        List<FeedbackModel> GetFeedbackByReaderId(string readerId);
        List<FeedbackModel> GetFeedbacks();
        void UpdateFeedbackToReaded(string readerId, string feedbackId);
    }
}