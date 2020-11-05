using System.Collections.Generic;
using System.Security.Claims;

namespace ADHApi.Helpers
{
    public interface IUserClaims
    {
        List<string> GetUserRole(IEnumerable<Claim> claims);
    }
}