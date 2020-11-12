using ADHUIServer.Handlers;
using ADHUIServer.Models;
using ADHUIServer.Models.Feedback;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ADHUIServer.Services
{
    public class FeedbackAccess : IFeedbackAccess
    {
        private const string Scheme = "Bearer";
        private readonly ICreateClientService _createClientService;
        public FeedbackAccess(ICreateClientService createClientService)
        {
            _createClientService = createClientService;
        }

        // public 
        public async Task<HttpInfoModel> SendNewFeedbakc(NewFeedbackModel feedbackInput)
        {
            HttpInfoModel RequestInfo = new HttpInfoModel();

            using (var response = await _createClientService.ApiClient.PostAsJsonAsync("api/Feedback", feedbackInput))
            {
                RequestInfo.StatusCode = response.StatusCode;
                RequestInfo.Message = await response.Content.ReadAsStringAsync();

                return RequestInfo;
            }
        }

        // Admin
        public async Task<(List<FeedbackModel>, HttpInfoModel)> GetFeedbacks_Admin(string token)
        {
            HttpInfoModel RequestInfo = new HttpInfoModel();

            _createClientService.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Scheme, token);

            using (var response = await _createClientService.ApiClient.GetAsync("api/Feedback/Admin"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<FeedbackModel> Feedbacks = await response.Content.ReadAsAsync<List<FeedbackModel>>();
                    RequestInfo.StatusCode = response.StatusCode;

                    return (Feedbacks, RequestInfo);
                }

                RequestInfo.StatusCode = response.StatusCode;
                RequestInfo.Message = await response.Content.ReadAsStringAsync();

                return (null, RequestInfo);
            }
        }

        public async Task<(List<FeedbackModel>, HttpInfoModel)> GetFeedbacksByReaderId_Admin(string token, string readerId)
        {
            HttpInfoModel RequestInfo = new HttpInfoModel();

            _createClientService.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Scheme, token);

            using (var response = await _createClientService.ApiClient.GetAsync($"api/Feedback/Admin/{readerId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<FeedbackModel> Feedbacks = await response.Content.ReadAsAsync<List<FeedbackModel>>();
                    RequestInfo.StatusCode = response.StatusCode;

                    return (Feedbacks, RequestInfo);
                }

                RequestInfo.StatusCode = response.StatusCode;
                RequestInfo.Message = await response.Content.ReadAsStringAsync();

                return (null, RequestInfo);
            }
        }


        // Admin and staff "Manager"
        public async Task<(List<FeedbackModel>, HttpInfoModel)> GetNotReadedFeedbacks(string token)
        {
            HttpInfoModel RequestInfo = new HttpInfoModel();

            _createClientService.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Scheme, token);

            using (var response = await _createClientService.ApiClient.GetAsync($"api/Feedback/NotReaded"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<FeedbackModel> Feedbacks = await response.Content.ReadAsAsync<List<FeedbackModel>>();
                    RequestInfo.StatusCode = response.StatusCode;

                    return (Feedbacks, RequestInfo);
                }

                RequestInfo.StatusCode = response.StatusCode;
                RequestInfo.Message = await response.Content.ReadAsStringAsync();

                return (null, RequestInfo);
            }
        }

        public async Task<(List<FeedbackModel>, HttpInfoModel)> GetFeedbacksByReaderId(string token)
        {
            HttpInfoModel RequestInfo = new HttpInfoModel();

            _createClientService.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Scheme, token);

            using (var response = await _createClientService.ApiClient.GetAsync($"api/Feedback/GetById"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<FeedbackModel> Feedbacks = await response.Content.ReadAsAsync<List<FeedbackModel>>();
                    RequestInfo.StatusCode = response.StatusCode;

                    return (Feedbacks, RequestInfo);
                }

                RequestInfo.StatusCode = response.StatusCode;
                RequestInfo.Message = await response.Content.ReadAsStringAsync();

                return (null, RequestInfo);
            }
        }

        public async Task<HttpInfoModel> UpdateFeedback(string token, string feedbackId)
        {
            HttpInfoModel RequestInfo = new HttpInfoModel();

            _createClientService.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Scheme, token);

            using (var response = await _createClientService.ApiClient.PutAsJsonAsync($"api/Feedback?feedbackId={feedbackId}", new { }))
            {
                RequestInfo.StatusCode = response.StatusCode;
                RequestInfo.Message = await response.Content.ReadAsStringAsync();

                return RequestInfo;
            }
        }
    }
}
