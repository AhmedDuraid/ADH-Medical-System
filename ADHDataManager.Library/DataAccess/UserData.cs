using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{

    public class UserData
    {
        // interface with the API 
        public List<UserModel> GetUserById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { @id = id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookUp", p, "AHDConnection");

            return output;
        }
    }
}
