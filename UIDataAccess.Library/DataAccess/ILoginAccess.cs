using System.Threading.Tasks;
using UIDataAccess.Library.Models;

namespace UIDataAccess.Library.DataAccess
{
    public interface ILoginAccess
    {
        Task<UserLoginInformationModel> GetUserToken(string username, string password);
    }
}