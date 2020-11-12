using ADHUIServer.Models;
using ADHUIServer.Models.Feedback;
using System.Threading.Tasks;

namespace ADHUIServer.Services
{
    public interface IFeedbackAccess
    {
        Task<HttpInfoModel> SendNewFeedbakc(FeedbackModel feedbackInput);
    }
}