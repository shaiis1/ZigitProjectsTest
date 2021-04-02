using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zigit_Backend.Models
{
    public class LoginResultModel
    {
        public string Token { get; set; }

        public UserModel UserModel { get; set; }
    }
}
