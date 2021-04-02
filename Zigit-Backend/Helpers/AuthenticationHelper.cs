using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Zigit_Backend.Interfaces;
using Zigit_Backend.JWTContainer.JWTModels;
using System.Security.Claims;
using Zigit_Backend.JWTContainer.JWTManagers;

namespace Zigit_Backend.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        #region Public Methods
        public string HashPassword(string password)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public string GenerateToken(Guid ID)
        {
            IAuthContainerModel containerModel = GetJWTContainerModel(ID);
            IAuthService authService = new JWTService(containerModel.SecretKey);

            return authService.GenerateToken(containerModel);
        }

        public static IAuthService GetJWTService()
        {
            IAuthContainerModel containerModel = new JWTContainerModel();
            return new JWTService(containerModel.SecretKey);
        }
        #endregion

        #region Private Methods
        private JWTContainerModel GetJWTContainerModel(Guid id)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[] { new Claim(ClaimTypes.NameIdentifier, id.ToString()) }
            };
        }
        #endregion
    }
}
