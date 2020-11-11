﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UIDataAccess.Library.Models;
using UIDataAccess.Library.Models.Admin;
using UIDataAccess.Library.Services;

namespace UIDataAccess.Library.DataAccess.Admin
{
    public class UsersDataAccess : IUsersDataAccess
    {
        private readonly ICreateClientService _createClientService;

        public UsersDataAccess(ICreateClientService createClientService)
        {
            _createClientService = createClientService;
        }

        public async Task<(List<UserModle>, HttpInfoModel)> GetUsers(string token)
        {
            HttpInfoModel httpInfo = new HttpInfoModel();

            _createClientService.ApiClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            using (HttpResponseMessage response =
                await _createClientService.ApiClient.GetAsync("api/Users/Admin"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<UserModle> users = await response.Content.ReadAsAsync<List<UserModle>>();
                    httpInfo.StatusCode = response.StatusCode;

                    return (users, httpInfo);
                }
                else
                {
                    httpInfo.StatusCode = response.StatusCode;
                    httpInfo.Message = await response.Content.ReadAsStringAsync();

                    return (null, httpInfo);
                }

            }
        }

        public async Task<HttpInfoModel> RegisterUser<T>(string token, T registerInfo)
        {
            HttpInfoModel httpInfo = new HttpInfoModel();
            _createClientService.ApiClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            using (HttpResponseMessage response =
               await _createClientService.ApiClient.PostAsJsonAsync("api/Account", registerInfo))
            {

                httpInfo.StatusCode = response.StatusCode;
                httpInfo.Message = await response.Content.ReadAsStringAsync();

                return httpInfo;
            }

        }
    }
}
