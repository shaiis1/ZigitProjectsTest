using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zigit_Backend.Interfaces
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(Guid ID);
        string HashPassword(string password);
    }
}
