using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.DbContent;
using Zigit_Backend.Interfaces;
using Zigit_Backend.Models;

namespace Zigit_Backend.DAL
{
    public class LoginDal : ILoginDal
    {
        private readonly ZigitContext _zigitContext;

        #region Constructor
        public LoginDal(ZigitContext zigitContext)
        {
            _zigitContext = zigitContext;
        }
        #endregion

        #region Public Methods
        public async Task<UserModel> GetUserByUsernameAndPasswordAsync(LoginModel loginModel)
        {
            return await _zigitContext.Users.FirstOrDefaultAsync(e => e.UserName == loginModel.UserName && e.Password == loginModel.Password);
        }

        public async Task<UserModel> GetByID(Guid ID)
        {
            return await _zigitContext.Users.FirstOrDefaultAsync(e => e.ID == ID);
        }
        #endregion
    }
}
