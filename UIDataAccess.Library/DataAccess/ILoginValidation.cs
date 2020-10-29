using System.Threading.Tasks;
using UIDataAccess.Library.Models;

namespace UIDataAccess.Library.DataAccess
{
    public interface ILoginValidation
    {
        Task<UserTokenModel> GetUserToken(string username, string password);
    }
}