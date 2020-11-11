using ADHUIServer.Handlers;
using ADHUIServer.Models;
using ADHUIServer.Models.Role;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ADHUIServer.Services
{
    public class RoleDataAccess : IRoleDataAccess
    {
        private readonly ICreateClientService _createClientService;
        public RoleDataAccess(ICreateClientService createClientService)
        {
            _createClientService = createClientService;
        }

        public async Task<(List<RoleModel>, HttpInfoModel)> GetRoles(string token)
        {
            _createClientService.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpInfoModel RequestInfo = new HttpInfoModel();

            using (var response = await _createClientService.ApiClient.GetAsync("api/Role/admin"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RoleModel> roles = await response.Content.ReadAsAsync<List<RoleModel>>();
                    RequestInfo.StatusCode = response.StatusCode;

                    return (roles, RequestInfo);
                }
                else
                {
                    RequestInfo.Message = await response.Content.ReadAsStringAsync();
                    RequestInfo.StatusCode = response.StatusCode;

                    return (null, RequestInfo);
                }
            }
        }

        public async Task<HttpInfoModel> AddRole(string token, string roleName)
        {
            _createClientService.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpInfoModel httpInfo = new HttpInfoModel();

            using (var response = await _createClientService.ApiClient.PostAsJsonAsync($"api/Role/admin/{roleName}", new { }))
            {
                if (response.IsSuccessStatusCode)
                {
                    httpInfo.StatusCode = response.StatusCode;

                    return httpInfo;
                }
                else
                {
                    httpInfo.StatusCode = response.StatusCode;
                    httpInfo.Message = await response.Content.ReadAsStringAsync();

                    return httpInfo;
                }
            }

        }

        public async Task<HttpInfoModel> UpdateRole(string token, RoleModel roleData)
        {
            _createClientService.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpInfoModel httpInfo = new HttpInfoModel();

            using (var response = await _createClientService.ApiClient.PutAsJsonAsync("api/Role/admin", roleData))
            {
                if (response.IsSuccessStatusCode)
                {
                    httpInfo.StatusCode = response.StatusCode;

                    return httpInfo;
                }
                else
                {
                    httpInfo.Message = await response.Content.ReadAsStringAsync();
                    httpInfo.StatusCode = response.StatusCode;

                    return httpInfo;

                }
            }

        }

        public async Task<HttpInfoModel> DeleteRole(string token, string roleId)
        {
            _createClientService.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpInfoModel httpInfo = new HttpInfoModel();

            using (var response = await _createClientService.ApiClient.DeleteAsync($"api/Role/admin/{roleId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    httpInfo.StatusCode = response.StatusCode;

                    return httpInfo;
                }
                else
                {
                    httpInfo.Message = await response.Content.ReadAsStringAsync();
                    httpInfo.StatusCode = response.StatusCode;

                    return httpInfo;
                }
            }

        }
    }
}
