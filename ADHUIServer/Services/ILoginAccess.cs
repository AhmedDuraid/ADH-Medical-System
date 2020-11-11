using ADHUIServer.Models.Users;
using System.Threading.Tasks;

namespace ADHUIServer.Services
{
    public interface ILoginAccess
    {
        Task<UserLoginInformationModel> GetUserToken(string username, string password);
    }
}