using LogicSolution.Model;
using LogicSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public IActionResult DurationFormatted([FromQuery][Required] int seconds)
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
        public IActionResult SumSmallestNumbers([FromQuery][Required] int[] numbers)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.SumSmallestNumbers(numbers) });
        }

        /// <summary>
        /// Takes an array of numbers and returns a new array, 1st element is count of positive numbers, 2nd element is sum of negative numbers.
        /// </summary>
        /// <param name="numbers">Array of integers</param>
        /// <returns>Returns a new array, 1st element is count of positive numbers, 2nd element is sum of negative numbers.</returns>
        [HttpGet("countSumNumbers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public IActionResult CountSumNumbers([FromQuery][Required] int[] numbers)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.CountSumNumbers(numbers) });
        }

        /// <summary>
        /// Takes an array of numbers as an argument. The function should move all zeroes to the end of the array
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns>Returns the modified array</returns>
        [HttpGet("moveZeroes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public IActionResult MoveZeroes([FromQuery][Required] int[] numbers)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.MoveZeroes(numbers) });
        }

        /// <summary>
        /// Takes an array of numbers as an arugment. The function will find and return the missing number between 1-10.
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns>The missing number</returns>
        [HttpGet("findMissingNumber")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public IActionResult FindMissingNumber([FromQuery][Required] int[] numbers)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.FindMissingNumber(numbers) });
        }

        /// <summary>
        /// Takes an array of numbers as an argument. The function should check if the array is sorted and in which order.
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns>The missing number</returns>
        [HttpGet("isSortedAndHow")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public IActionResult IsSortedAndHow([FromQuery][Required] int[] numbers)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.IsSortedAndHow(numbers) });
        }

        /// <summary>
        /// Takes a number as parameter. Sum all positive numbers smaller than the given number divisible by 5 or 3
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>Sum smaller than the given number divisible by 5 or 3</returns>
        [HttpGet("sumMultiples")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public IActionResult SumMultiples([FromQuery][Required]int number)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.SumMultiples(number) });
        }

        /// <summary>
        /// If the number is even, divide it into two closest odd numbers where sum is the number, else return the number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet("divideIntoOdd")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public IActionResult DivideIntoOdd(int number)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.DivideIntoOdd(number) });
        }

        /// <summary>
        /// The function must calculate parameter 1, raised to the power of parameter 2, and return result and the last digit of the resulting value.
        /// </summary>
        /// <param name="baseNum">Base Number</param>
        /// <param name="powerNum">Power</param>
        /// <returns>Return the answer and last digit of the resulting value</returns>
        [HttpGet("powerLastDigit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public IActionResult PowerLastDigit([FromQuery][Required] double baseNum, [FromQuery][Required] double powerNum)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.PowerLastDigit(baseNum, powerNum) });
        }

        /// <summary>
        /// The function must count characters, words and lines, returning an object with these values.
        /// </summary>
        /// <param name="phrase">Phrase</param>
        /// <returns>Count on each</returns>
        [HttpGet("phraseParser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PhraseParser))]
        public IActionResult PhraseParser([FromQuery][Required]string phrase)
        {
            return Ok(new CommonResponse() { Data = _influencerCodeService.PhraseParser(phrase) });
        }
    }
}
