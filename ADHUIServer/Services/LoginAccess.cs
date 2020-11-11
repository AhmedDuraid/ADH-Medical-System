using ADHUIServer.Handlers;
using ADHUIServer.Models.Users;
using System.Net.Http;
using System.Threading.Tasks;

namespace ADHUIServer.Services
{
    public class LoginAccess : ILoginAccess
    {
        private readonly ICreateClientService _createClientService;
        public LoginAccess(ICreateClientService createClientService)
        {
            _createClientService = createClientService;
        }



        public async Task<UserLoginInformationModel> GetUserToken(string username, string password)
        {
            using (HttpResponseMessage responseMessage =
                await _createClientService.ApiClient.PostAsync($"/Token?username={username}&password={password}", null))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    // to read from body 
                    UserLoginInformationModel Response = await responseMessage.Content.ReadAsAsync<UserLoginInformationModel>();
                    Response.Error.StatusCode = responseMessage.StatusCode;

                    return Response;

                }
                else
                {
                    UserLoginInformationModel userInformatiomModel = new UserLoginInformationModel();
                    userInformatiomModel.Error.Message = await responseMessage.Content.ReadAsStringAsync();
                    userInformatiomModel.Error.StatusCode = responseMessage.StatusCode;

                    return userInformatiomModel;
                }
            }

        }
    }
}
