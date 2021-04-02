using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.Interfaces;
using Zigit_Backend.Models;

namespace Zigit_Backend.Controllers
{
    [Route("Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
            private readonly ILoginManager _loginManager;

            #region Constructor
            public AuthenticationController(ILoginManager loginManager)
            {
                _loginManager = loginManager;
            }
            #endregion

            #region Public API Methods
            [HttpPost]
            [Route("Login")]
            public async Task<IActionResult> GetAll([FromBody] LoginModel loginModel)
            {
                try
                {
                    LoginResultModel loginResultModel = await _loginManager.LoginAsync(loginModel);
                    return Ok(loginResultModel);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Bad Request Here {ex.Message}");
                }
            }
           
            #endregion
    }
}
