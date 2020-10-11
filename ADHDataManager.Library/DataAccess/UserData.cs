﻿using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{

    public class UserData
    {
        // interface with the API 
        private readonly string ConnectionName = "AHDConnection";
        private readonly IConfiguration _configuration;

        public UserData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<UserModel> GetUsers()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            return sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUsers_GetUsers",
                new { }, ConnectionName);
        }

        public List<UserModel> GetUserById(int id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var Parameters = new { @id = id };

            var output = sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUsers_GetUserById", Parameters,
                ConnectionName);

            return output;
        }

        public void CreateUser(UserModel user)
        {

            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var Parameters = new
            {
                @UserName = user.user_name,
                @FirstName = user.first_name,
                @MiddleName = user.middle_name,
                @LastName = user.last_name,
                @Password = user.password,
                @Email = user.email,
                @BirthDate = user.birth_date,
                @Gender = user.gender,
                @Nationality = user.nationality,
                @Address = user.address
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spUsers_CreateUser",
                Parameters, ConnectionName);
        }
    }
}
