using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class FeedbackData : IFeedbackData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public FeedbackData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<FeedbackModel> GetFeedbacks()
        {
            List<FeedbackModel> output = _sqlDataAccess.LoadData<FeedbackModel, dynamic>("dbo.spFeedback_FindAll", new { });

            return output;
        }

        public List<FeedbackModel> GetFeedbackByNotReaded()
        {
            List<FeedbackModel> output = _sqlDataAccess.LoadData<FeedbackModel, dynamic>("dbo.spFeedback_FindAllNotReaded", new { });

            return output;
        }

        public List<FeedbackModel> GetFeedbackByReaderId(string readerId)
        {
            List<FeedbackModel> output = _sqlDataAccess.LoadData<FeedbackModel, dynamic>("dbo.spFeedback_FindAllReadedId", new { @ReaderId = readerId });

            return output;
        }
        public void AddNewFeedback(FeedbackModel feedback)
        {
            var Parameters = new
            {
                @Id = feedback.Id,
                @Titel = feedback.Titel,
                @Name = feedback.Name,
                @Email = feedback.Email,
                @Phone = feedback.Phone,
                @FeedbackBody = feedback.FeedbackBody
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spFeedback_AddNew", Parameters);
        }

        public void UpdateFeedbackToReaded(string readerId, string feedbackId)
        {
            var Parameters = new
            {
                @ReaderId = readerId,
                @FeedbackId = feedbackId
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spFeedback_UpdateFeedbackToReaded", Parameters);
        }
    }
}
