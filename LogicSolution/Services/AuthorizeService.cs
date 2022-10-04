using LogicSolution.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace LogicSolution.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private List<UserModel> superAdmin = new List<UserModel>() {
            new UserModel() { UserName = "systemadmin", Password = "password" }
            , new UserModel() { UserName = "logicsolution", Password = "test1234" }
        };
        private string key { get; set; }

        public AuthorizeService(string key)
        {
            this.key = key;
        }

        public UserModel Authenticate(UserModel userModel)
        {
            return superAdmin.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
        }

        public string GenerateToken(UserModel userModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userModel.UserName)
            };

            var token = new JwtSecurityToken(null,
                null,
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
    }
}
