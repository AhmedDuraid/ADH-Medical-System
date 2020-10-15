using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class FeedbackData
    {
        // interface with the API 
        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        private readonly SqlDataAccess dataAccess;
        public FeedbackData(IConfiguration configuration)
        {
            dataAccess = new SqlDataAccess();
            _connectionString = configuration.GetConnectionString(connectionName);

        }

        public List<FeedbackModel> GetFeedbacks()
        {


            List<FeedbackModel> output = dataAccess.LoadData<FeedbackModel, dynamic>("dbo.spFeedback_FindAll",
                new { }, _connectionString);

            return output;
        }

        public List<FeedbackModel> GetFeedbackByNotReaded()
        {


            List<FeedbackModel> output = dataAccess.LoadData<FeedbackModel, dynamic>("dbo.spFeedback_FindAllNotReaded",
                new { }, _connectionString);

            return output;

        }

        public List<FeedbackModel> GetFeedbackByReaderId(string readerId)
        {


            List<FeedbackModel> output = dataAccess.LoadData<FeedbackModel, dynamic>("dbo.spFeedback_FindAllReadedId",
                new { @ReaderId = readerId }, _connectionString);

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

            dataAccess.SaveData<dynamic>("dbo.spFeedback_AddNew", Parameters, _connectionString);

        }

        public void UpdateFeedbackToReaded(string readerId, string feedbackId)
        {
            var Parameters = new
            {
                @ReaderId = readerId,
                @FeedbackId = feedbackId
            };
            dataAccess.SaveData<dynamic>("dbo.spFeedback_UpdateFeedbackToReaded", Parameters, _connectionString);
        }
    }
}
