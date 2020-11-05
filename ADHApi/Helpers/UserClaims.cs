using System.Collections.Generic;
using System.Security.Claims;
namespace ADHApi.Helpers
{
    public class UserClaims : IUserClaims
    {

        public List<string> GetUserRole(IEnumerable<Claim> claims)
        {
            List<string> UserRoles = new List<string>();
            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.Role)
                {
                    UserRoles.Add(claim.Value);
                }

            }

            return UserRoles;
        }
    }
}
