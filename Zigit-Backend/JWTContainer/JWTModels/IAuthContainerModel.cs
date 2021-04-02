﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Zigit_Backend.JWTContainer.JWTModels
{
    public interface IAuthContainerModel
    {
        #region Members
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }

        Claim[] Claims { get; set; }
        #endregion
    }
}
