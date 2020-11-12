using ADHUIServer.Models;
using ADHUIServer.Models.Feedback;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADHUIServer.Services
{
    public interface IFeedbackAccess
    {
        Task<(List<FeedbackModel>, HttpInfoModel)> GetFeedbacksByReaderId(string token);
        Task<(List<FeedbackModel>, HttpInfoModel)> GetFeedbacksByReaderId_Admin(string token, string readerId);
        Task<(List<FeedbackModel>, HttpInfoModel)> GetFeedbacks_Admin(string token);
        Task<(List<FeedbackModel>, HttpInfoModel)> GetNotReadedFeedbacks(string token);
        Task<HttpInfoModel> SendNewFeedbakc(NewFeedbackModel feedbackInput);
        Task<HttpInfoModel> UpdateFeedback(string token, string feedbackId);
    }
}