using ADHUIServer.Handlers;
using ADHUIServer.Models;
using ADHUIServer.Models.Feedback;
using System.Net.Http;
using System.Threading.Tasks;

namespace ADHUIServer.Services
{
    public class FeedbackAccess : IFeedbackAccess
    {
        private readonly ICreateClientService _createClientService;
        public FeedbackAccess(ICreateClientService createClientService)
        {
            _createClientService = createClientService;
        }

        public async Task<HttpInfoModel> SendNewFeedbakc(FeedbackModel feedbackInput)
        {
            HttpInfoModel RequestInfo = new HttpInfoModel();

            using (var response = await _createClientService.ApiClient.PostAsJsonAsync("api/Feedback", feedbackInput))
            {
                RequestInfo.StatusCode = response.StatusCode;
                RequestInfo.Message = await response.Content.ReadAsStringAsync();

                return RequestInfo;
            }
        }
    }
}
