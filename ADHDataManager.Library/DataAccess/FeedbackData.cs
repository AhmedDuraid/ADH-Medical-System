using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class FeedbackData
    {
        // interface with the API 
        private readonly string DataConnectionName = "AHDConnection";


        public List<FeedbackModel> GetFeedbacks()
        {
            SqlDataAccess dataAccess = new SqlDataAccess();

            List<FeedbackModel> output = dataAccess.LoadData<FeedbackModel, dynamic>("dbo.spFeedback_GetAllUnreadedFeedback",
                new { }, DataConnectionName);

            return output;
        }

        public List<FeedbackModel> GetFeedbackByID(int id)
        {
            SqlDataAccess dataAccess = new SqlDataAccess();

            List<FeedbackModel> output = dataAccess.LoadData<FeedbackModel, dynamic>("dbo.spFeedback_GetFeedbackByID",
                new { @ID = id }, DataConnectionName);

            return output;

        }
        public void AddFeedback(FeedbackModel feedback)
        {
            SqlDataAccess dataAccess = new SqlDataAccess();

            var Parameters = new
            {
                @Titel = feedback.titel,
                @Name = feedback.name,
                @Email = feedback.email,
                @Phone = feedback.phone,
                @FeedbackBody = feedback.feedback_body
            };

            dataAccess.SaveData<dynamic>("dbo.spFeedback_insertNewFeedback", Parameters, DataConnectionName);

        }
    }
}
