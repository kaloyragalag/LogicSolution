using LogicSolution.Model;
using LogicSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        /// The function returns a human-readable format given a value of seconds in integer. Ex: 1 hour, 1 minute, 2 seconds
        /// </summary>
        /// <param name="seconds">Value of seconds in integer</param>
        /// <returns>A string in a human-readable format. Ex: 1 hour, 1 minute, 2 seconds</returns>
        [HttpGet("durationFormatted")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public IActionResult DurationFormatted([FromQuery][Required]int seconds)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.DurationFormatted(seconds) });
        }

        /// <summary>
        /// The function returns the sum of the two smallest numbers in the array of numbers
        /// </summary>
        /// <param name="numbers">Array of numbers</param>
        /// <returns>Returns the sum of the two smallest numbers in the array</returns>
        [HttpGet("sumSmallestNumbers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public IActionResult SumSmallestNumbers([FromQuery][Required]int[] numbers)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.SumSmallestNumbers(numbers) });
        }
    }
}
