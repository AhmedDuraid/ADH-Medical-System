using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{

    public class UserData
    {
        // interface with the API 
        private SqlDataAccess _sqlDataAccess;

        public UserData()
        {
            _sqlDataAccess = new SqlDataAccess();
        }

        public List<UserModel> GetUsers(string connectionString)
        {

            var output = _sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUsers_GetUsers",
                new { }, connectionString);

            return output;
        }

        public List<UserModel> GetUserById(string id, string connectionString)
        {

            if (id != null)
            {
                var Parameters = new { @UserId = id };

                var output = _sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUsers_FindUserByID",
                    Parameters, connectionString);

                return output;
            }
            return null;
        }

        public void UpdateUser(dynamic parameters, string connectionString)
        {

           _sqlDataAccess.SaveData<dynamic>("dbo.spUsers_UpdateUserByID", parameters, connectionString);

        }


    }
}
