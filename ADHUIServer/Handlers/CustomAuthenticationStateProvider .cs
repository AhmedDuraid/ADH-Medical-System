using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADHUIServer.Handlers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private ClaimsIdentity Identity;
        private ClaimsPrincipal UserPrincipal;
        private List<Claim> UserClaims;
        private List<string> UserRoles;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // chaeck if the user is login before 
            string usrId = await _sessionStorageService.GetItemAsync<string>("Id");
            string Token = await _sessionStorageService.GetItemAsync<string>("Token");
            UserRoles = await _sessionStorageService.GetItemAsync<List<string>>("Roles");

            if (usrId != null && Token != null && UserRoles != null)
            {
                // if user login will do his idintity claims
                UserClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,usrId)

                };

                foreach (var item in UserRoles)
                {
                    UserClaims.Add(new Claim(ClaimTypes.Role, item));

                }
                Identity = new ClaimsIdentity(UserClaims, "apiauth_type");
            }
            else
            {
                Identity = new ClaimsIdentity();

            }

            UserPrincipal = new ClaimsPrincipal(Identity);

            return await Task.FromResult(new AuthenticationState(UserPrincipal));
        }

        // if the user login for the first time 
        public async void AuthenticatedUser(string token, string userName)
        {
            // read the token
            JwtSecurityToken UserToken = new JwtSecurityToken(token);
            UserClaims = new List<Claim>();
            UserRoles = new List<string>();

            foreach (var tokenItem in UserToken.Claims)
            {
                if (tokenItem.Type == ClaimTypes.NameIdentifier)
                {
                    UserClaims.Add(new Claim(ClaimTypes.NameIdentifier, tokenItem.Value));

                    await _sessionStorageService.SetItemAsync("Id", tokenItem.Value);

                }

                if (tokenItem.Type == ClaimTypes.Role)
                {
                    UserClaims.Add(new Claim(ClaimTypes.Role, tokenItem.Value));
                    UserRoles.Add(tokenItem.Value);

                }
            }

            Identity = new ClaimsIdentity(UserClaims, "apiauth_type");
            UserPrincipal = new ClaimsPrincipal(Identity);

            // store the data in sesstion 
            await _sessionStorageService.SetItemAsync("Roles", UserRoles);
            await _sessionStorageService.SetItemAsync("Token", token);
            await _sessionStorageService.SetItemAsync("UserName", userName);

            // update the Auth state 
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(UserPrincipal)));
        }

        public void UserLogOut()
        {
            Identity = new ClaimsIdentity();
            UserPrincipal = new ClaimsPrincipal(Identity);

            _sessionStorageService.RemoveItemAsync("Id");
            _sessionStorageService.RemoveItemAsync("Token");
            _sessionStorageService.RemoveItemAsync("Roles");
            _sessionStorageService.RemoveItemAsync("UserName");

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(UserPrincipal)));
        }
    }
}
