using LogicSolution.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogicSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfluencerCodeController : ControllerBase
    {
        private IInfluencerCodeService _influencerCodeService;
        public InfluencerCodeController(IInfluencerCodeService influencerCodeService)
        {
            _influencerCodeService = influencerCodeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
