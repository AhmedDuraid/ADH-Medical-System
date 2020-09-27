using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET: api/User/5
        public List<UserModel> GetByID(int id)
        {

            UserData data = new UserData();

            return data.GetUserById(id);
        }



    }
}
