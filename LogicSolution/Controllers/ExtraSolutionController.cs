using LogicSolution.Model;
using LogicSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LogicSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtraSolutionController : ControllerBase
    {
        //https://html-agility-pack.net/knowledge-base/37936630/how-to-extract-meta-tags-of-a-series-of-urls-without-downloading-whole-html-in-csharp
        private IExtraSolutionService _extraSolutionService;

        public ExtraSolutionController(IExtraSolutionService extraSolutionService)
        {
            this._extraSolutionService = extraSolutionService;
        }

        /// <summary>
        /// The function will extract the meta data from a given url link.
        /// </summary>
        /// <param name="link">Link</param>
        /// <returns>Meta Data</returns>
        [HttpGet("extractMetaData")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MetaData))]
        public async Task<IActionResult> ExtractMetaData([FromQuery][Required] string link)
        {
            try
            {
                return Ok(new CommonResponse()
                {
                    Data = await _extraSolutionService.ExtractMetaData(link)
                }); ;
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse() { IsError = true, UserMessage = "Failed", Data = ex.Message });
            }
        }

    }
}
