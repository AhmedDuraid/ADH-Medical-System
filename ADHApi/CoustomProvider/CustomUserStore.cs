﻿using ADHDataManager.Library.DataAccess.AuthDataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ADHApi.CoustomProvider
{
    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>,
        IUserEmailStore<ApplicationUser>
    {
        private readonly string _connectionString;
        private readonly AccountData _userData = new AccountData();


        public CustomUserStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AHDConnection");

        }
        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var p = new
            {
                @UserId = user.Id.ToString(),
                @UserName = user.UserName.ToString(),
                @Email = user.Email.ToString(),
                @Password = user.PasswordHash.ToString(),
                @NormalizedUserName = user.NormalizedUserName,
                @FirstName = user.FirstName,
                @LastName = user.LastName,
                @NormalizedEmail = user.NormalizedEmail
            };

            await _userData.AddNewUser<dynamic>(_connectionString, p, "dbo.spUsers_AddUser_Auth");

            return IdentityResult.Success;

        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var Parameters = new { @UserId = userId.ToString() };

            var userInfo = await _userData.LoadUserById<ApplicationUser, dynamic>
                (_connectionString, Parameters, "dbo.spUsers_GetUserById_Auth");

            return userInfo;

        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Parameters = new
            {
                @NormalizedUserName = normalizedUserName
            };

            var UserInfo = await _userData.LoadUserByName
                <ApplicationUser, dynamic>(_connectionString, Parameters, "dbo.spUsers_GetUserByName_Auth");

            return UserInfo;
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName = normalizedName);
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        // password store 
        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
        // email store 
        public async Task<ApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var Parameters = new { @NormalizedEmail = normalizedEmail };

            var UserInfo = await _userData.LoadUserByEmail<ApplicationUser, dynamic>
                (
                _connectionString, Parameters, "dbo.spUsers_GetUserByEmail_Auth"
                );

            return UserInfo;
        }

        public Task<string> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)
        {

            return Task.FromResult(user.NormalizedEmail = normalizedEmail);
        }
    }
}
