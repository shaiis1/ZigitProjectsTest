using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.Models;

namespace Zigit_Backend.Interfaces
{
    public interface ILoginManager
    {
        Task<LoginResultModel> LoginAsync(LoginModel loginModel);
        Task<UserModel> GetByID(Guid ID, bool includePassword = false);
    }
}
