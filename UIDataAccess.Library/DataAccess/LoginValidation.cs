using System;
using System.Net.Http;
using System.Threading.Tasks;
using UIDataAccess.Library.Models;
using UIDataAccess.Library.Services;

namespace UIDataAccess.Library.DataAccess
{
    public class LoginValidation : ILoginValidation
    {
        private readonly ICreateClientService _createClientService;
        public LoginValidation(ICreateClientService createClientService)
        {
            _createClientService = createClientService;
        }



        public async Task<UserTokenModel> GetUserToken(string username, string password)
        {
            using (HttpResponseMessage responseMessage =
                await _createClientService.ApiClient.PostAsync($"/Token?username={username}&password={password}", null))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var Response = await responseMessage.Content.ReadAsAsync<UserTokenModel>();

                    return Response;

                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }

        }
    }
}
