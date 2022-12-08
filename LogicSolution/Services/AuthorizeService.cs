using LogicSolution.Data;
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
        private readonly DataContext _context;

        private List<UserModel> superAdmin = new List<UserModel>() {
            new UserModel() { UserName = "systemadmin", Password = "password" }
            , new UserModel() { UserName = "logicsolution", Password = "test1234" }
        };
        private string key { get; set; }

        public AuthorizeService(string key)
        {
            this.key = key;
        }

        public User Authenticate(DataContext context, UserModel userModel)
        {
            return _context.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
        }

        public UserToken GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName)
            };

            var token = new JwtSecurityToken(null,
                null,
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);

            return new UserToken() { Token = new JwtSecurityTokenHandler().WriteToken(token), Name = string.Format("{0} {1}", user.FirstName, user.LastName), Email = user.Email };
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
