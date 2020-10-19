using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{

    public class UserData
    {

        private readonly SqlDataAccess _sqlDataAccess;

        public UserData(IConfiguration configuration)
        {
            _sqlDataAccess = new SqlDataAccess(configuration);
        }

        public List<UserModel> GetUsers()
        {
            var output = _sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUsers_GetUsers", new { });

            return output;
        }

        public List<UserModel> GetUserById(string id)
        {
            if (id != null)
            {
                var Parameters = new { @UserId = id };
                var output = _sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUsers_FindUserByID", Parameters);

                return output;
            }
            return null;
        }

        public void UpdateUser(UserModel user)
        {
            var Parameters = new
            {
                @UserId = user.Id,
                @FirstName = user.FirstName,
                @MiddleName = user.MiddleName,
                @LastName = user.LastName,
                @BirthDate = user.BirthDate,
                @PhoneNumber = user.PhoneNumber,
                @Gender = user.Gender,
                @Nationality = user.Nationality,
                @Address = user.Address

            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spUsers_UpdateUserByID", Parameters);
        }

        public void DeleteUser(string userId)
        {
            var parameters = new { @UserId = userId };

            _sqlDataAccess.SaveData<dynamic>("dbo.spUsers_DeleteUser", parameters);
        }
    }
}
