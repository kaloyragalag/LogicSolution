using LogicSolution.Data;
using LogicSolution.Model;
using LogicSolution.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LogicSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        //https://www.youtube.com/watch?v=bRtCifC6JsQ&ab_channel=KevinGutierrez
        //https://www.c-sharpcorner.com/article/jwt-token-creation-authentication-and-authorization-in-asp-net-core-6-0-with-po/
        private IAuthorizeService authorizeService;
        private readonly DataContext _context;

        public AuthorizationController(IAuthorizeService authorizeService, DataContext context)
        {
            this.authorizeService = authorizeService;
            this._context = context;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="userLogin">User details</param>
        /// <returns>Token</returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody] UserModel userLogin)
        {
            User user = _context.Users.Where(x => x.UserName == userLogin.UserName && x.Password == userLogin.Password).FirstOrDefault();
            if (user != null)
            {
                var token = authorizeService.GenerateToken(user);
                return Ok(new CommonResponse() { IsError = false, Data = token, UserMessage = "Successful authentication."});
            }
            else
            {
                return NotFound(new CommonResponse() { IsError = true, UserMessage = "User does not exist or incorrect password."});
            }
        }
    }
}
