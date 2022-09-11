using LogicSolution.Model;
using LogicSolution.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogicSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        //https://www.youtube.com/watch?v=bRtCifC6JsQ&ab_channel=KevinGutierrez
        //https://www.c-sharpcorner.com/article/jwt-token-creation-authentication-and-authorization-in-asp-net-core-6-0-with-po/
        private IAuthorizeService authorizeService;

        public AuthorizationController(IAuthorizeService authorizeService)
        {
            this.authorizeService = authorizeService;
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
            UserModel userModel = authorizeService.Authenticate(userLogin);
            if (userModel != null)
            {
                var token = authorizeService.GenerateToken(userModel);
                return Ok(new CommonResponse() { IsError = false, Data = token, UserMessage = "Successful authentication."});
            }
            else
            {
                return NotFound(new CommonResponse() { IsError = true, UserMessage = "User does not exist or incorrect password."});
            }
        }
    }
}
