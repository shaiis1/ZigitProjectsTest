﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.Interfaces;
using Zigit_Backend.Models;

namespace Zigit_Backend.Managers
{
    public class LoginManager : ILoginManager
    {
        private readonly ILoginDal _loginDal;
        private readonly IAuthenticationHelper _authenticationHelper;

        #region Constructor
        public LoginManager(ILoginDal loginDal, IAuthenticationHelper authenticationHelper)
        {
            _loginDal = loginDal;
            _authenticationHelper = authenticationHelper;
        }
        #endregion

        #region Public Methods
        public async Task<LoginResultModel> LoginAsync(LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.UserName) || string.IsNullOrEmpty(loginModel.Password))
                throw new ArgumentException("Invalid arguments.");

            loginModel.Password = _authenticationHelper.HashPassword(loginModel.Password);
            UserModel userModel = await _loginDal.GetUserByUsernameAndPasswordAsync(loginModel);

            if (userModel == null)
                throw new Exception("User not exists.");

            userModel.Password = "Classified";

            string token = _authenticationHelper.GenerateToken(userModel.ID);

            return new LoginResultModel() { UserModel = userModel, Token = token };
        }

        public async Task<UserModel> GetByID(Guid ID, bool includePassword = false)
        {
            if (ID == Guid.Empty)
                throw new ArgumentException("Invalid ID.");

            UserModel userModel = await _loginDal.GetByID(ID);

            if (!includePassword)
                userModel.Password = "Classified";

            return userModel;
        }
        #endregion
    }
}
