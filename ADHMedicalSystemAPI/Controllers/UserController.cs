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
        // GET: api/User
        public List<UserModel> GetUsers()
        {
            UserData userData = new UserData();

            return userData.GetUsers();
        }

        // GET: api/User/5
        public List<UserModel> GetByID(int id)
        {

            UserData data = new UserData();

            return data.GetUserById(id);
        }

        // POST: api/User
        public void Post([FromBody] UserModel user)
        {
            UserData userData = new UserData();

            userData.CreateUser(user);

        }




    }
}
