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
        private IAuthorizeService authorizeService;

        public AuthorizationController(IAuthorizeService authorizeService)
        {
            this.authorizeService = authorizeService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] UserModel userLogin)
        {
            UserModel userModel = authorizeService.Authenticate(userLogin);
            if (userModel != null)
            {
                var token = authorizeService.GenerateToken(userModel);
                return Ok(token);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
