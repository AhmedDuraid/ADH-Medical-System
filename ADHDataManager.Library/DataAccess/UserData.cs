using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{

    public class UserData
    {
        // interface with the API 
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly string _connectionString;
        private readonly string _connectionName = "AHDConnection";

        public UserData(IConfiguration configuration)
        {
            _sqlDataAccess = new SqlDataAccess();
            _connectionString = configuration.GetConnectionString(_connectionName);

        }

        public List<UserModel> GetUsers()
        {

            var output = _sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUsers_GetUsers",
                new { }, _connectionString);

            return output;
        }

        public List<UserModel> GetUserById(string id)
        {
            if (id != null)
            {
                var Parameters = new { @UserId = id };

                var output = _sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUsers_FindUserByID",
                    Parameters, _connectionString);

                return output;
            }
            return null;
        }

        public void UpdateUser(string id, string firstName, string middleName, string lastName,
            DateTime birthDate, string phoneNumber, char gender, string nationality, string address)
        {
            var Parameters = new
            {
                @UserId = id,
                @FirstName = firstName,
                @MiddleName = middleName,
                @LastName = lastName,
                @BirthDate = birthDate,
                @PhoneNumber = phoneNumber,
                @Gender = gender,
                @Nationality = nationality,
                @Address = address

            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spUsers_UpdateUserByID", Parameters, _connectionString);

        }

        public void DeleteUser(string userId)
        {
            var parameters = new { @UserId = userId };

            _sqlDataAccess.SaveData<dynamic>("dbo.spUsers_DeleteUser", parameters, _connectionString);

        }


    }
}
