using LogicSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogicSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeWarsController : ControllerBase
    {
        private ICodeWarsService _codeWarsService;
        /// <summary>
        /// All the logic solution in the CodeWars platform
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="codeWarsService">Repository</param>
        public CodeWarsController(ICodeWarsService codeWarsService)
        {
            _codeWarsService = codeWarsService;
        }

        /// <summary>
        /// The function will break up camel casing, using a space between words. Example: "camelCasing" => "camel Casing"
        /// </summary>
        /// <param name="camelCaseText">Camel Case Text</param>
        /// <returns>Camel Case Text separated by space</returns>
        [HttpGet("breakcamelcase")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonResponse))]
        public async Task<IActionResult> BreakCamelCase([FromQuery][Required] string camelCaseText)
        {
            return Ok(new CommonResponse()
            {
                IsError = false,
                Data = _codeWarsService.BreakCamelCase(camelCaseText),
                UserMessage = "Success!"
            });
        }

        /// <summary>
        /// The function that will find all the anagrams of a word from a list. Example: anagrams('abba', ['aabb', 'abcd', 'bbaa', 'dada']) => ['aabb', 'bbaa']
        /// </summary>
        /// <param name="word">Main Word</param>
        /// <param name="words">List of Words</param>
        /// <returns>An array of all the anagrams or an empty array if there are none.</returns>
        [HttpGet("anagrams")]
        public List<string> Anagrams([FromQuery]string word, [FromQuery]List<string> words)
        {
            return _codeWarsService.Anagrams(word, words);
        }

        /// <summary>
        /// ROT13 is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in the alphabet.
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>The string ciphered with Rot13</returns>
        [HttpGet("rot13")]
        public string Rot13([FromQuery]string message)
        {
            return _codeWarsService.Rot13(message);
        }

        /// <summary>
        /// A pangram is a sentence that contains every single letter of the alphabet at least once.
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        [HttpGet("pangram")]
        public bool IsPangram([FromQuery]string text)
        {
            return _codeWarsService.IsPangram(text);
        }

        /// <summary>
        /// This function replaces every letter with its position in the alphabet. If anything in the text isn't a letter, ignore it and don't return it. "a" = 1, "b" = 2, etc.
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        [HttpGet("alphabetposition")]
        public string AlphabetPosition([FromQuery] string text)
        {
            return _codeWarsService.AlphabetPosition(text);
        }


        /// <summary>
        /// This function will find the missing letter in an array of characters. ["a","b","c","d","f"] => "e"
        /// </summary>
        /// <param name="array">Array of Characters</param>
        /// <returns>The missing letter in the array</returns>
        [HttpGet("findmissingletter")]
        public char FindMissingLetter([FromQuery] char[] array)
        {
            return _codeWarsService.FindMissingLetter(array);
        }

        /// <summary>
        /// The function will convert the RGB decimal value to hexadecimal value. Rgb(255, 255, 255) # returns FFFFFF
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        /// <returns>RGB hexadecimal value</returns>
        [HttpGet("rgbtohex")]
        public string RGBToHex(int r, int g, int b)
        {
            return _codeWarsService.RGBToHex(r, g, b);
        }

        /// <summary>
        /// The function will check whether the board's current state is solved. 
        /// </summary>
        /// <param name="board">Tic-Tac-Toe Board</param>
        /// <returns>
        /// -1 if the board is not yet finished AND no one has won yet (there are empty spots),
        /// 1 if "X" won,
        /// 2 if "O" won,
        /// 0 if it's a cat's game (i.e. a draw).
        /// </returns>
        [HttpGet("tictactoechecker")]
        public int TicTacToeChecker()
        {
            return _codeWarsService.TicTacToeChecker(new int[,] { { 2, 1, 2 }, { 2, 1, 1 }, { 1, 2, 0 } });
        }
    }
}
