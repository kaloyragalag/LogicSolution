using LogicSolution.Model;
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
        /// A function that would take the morse code as input and return a decoded human-readable string
        /// </summary>
        /// <param name="morseCode">Morse Code</param>
        /// <returns>Decoded Human-readable string</returns>
        [HttpGet("decodeMorseCode")]
        public string DecodeMorseCode(string morseCode)
        {
            return _codeWarsService.DecodeMorseCode(morseCode);
        }

        /// <summary>
        /// Given an array of integers, find the one that appears an odd number of times. There will always be only one integer that appears an odd number of times.
        /// </summary>
        /// <param name="seq">Array of Integers</param>
        /// <returns>the one that appears an odd number of times</returns>
        [HttpGet("findOddInteger")]
        public int FindOddInteger([FromQuery]int[] seq)
        {
            return _codeWarsService.FindOddInteger(seq);
        }

        /// <summary>
        /// Return the number (count) of vowels in the given string.The input string will only consist of lower case letters and/or spaces.
        /// </summary>
        /// <param name="str">Text</param>
        /// <returns>Vowel count</returns>
        [HttpGet("getvowelcount")]
        public int GetVowelCount([FromQuery]string str)
        {
            return _codeWarsService.GetVowelCount(str);
        }

        /// <summary>
        /// To be a senior, a member must be at least 55 years old and have a handicap greater than 7. Handicaps range from -2 to +26.
        /// </summary>
        /// <param name="data">List of pairs that consists of an integer for the person's age and an integer for the person's handicap</param>
        /// <returns>Whether the respective member is to be placed in the senior or open category</returns>
        [HttpPost("openOrSenior")]
        public IEnumerable<string> OpenOrSenior([FromBody]int[][] data)
        {
            return _codeWarsService.OpenOrSenior(data);
        }

        /// <summary>
        /// Take 2 strings s1 and s2 including only letters from a to z. Return a new sorted string, containing distinct letters from s1 or s2.
        /// </summary>
        /// <param name="s1">String 1</param>
        /// <param name="s2">String 2</param>
        /// <returns>Sorted distinct string</returns>
        [HttpGet("twoToOnelongest")]
        public string TwoToOneLongest([FromQuery]string s1, [FromQuery]string s2)
        {
            return _codeWarsService.TwoToOneLongest(s1, s2);
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
        [HttpPost("tictactoechecker")]
        public int TicTacToeChecker([FromBody] List<int[]> board)
        {
            return _codeWarsService.TicTacToeChecker(board.To2DArray());
        }

        /// <summary>
        /// Move the first letter of each word to the end of it, then add "ay" to the end of the word.
        /// </summary>
        /// <param name="word">Word</param>
        /// <returns>Pig Latin Word</returns>
        [HttpGet("piglatin")]
        public string PigLatin([FromQuery] string word)
        {
            return _codeWarsService.PigLatin(word);
        }

        /// <summary>
        /// Accepts a 2D array representing a Sudoku board, and returns whether it is valid or not. Boards containing one or more zeroes are considered to be invalid solution.
        /// </summary>
        /// <param name="board">2D board</param>
        /// <returns>True/False</returns>
        [HttpPost("sudokuvalidator")]
        public bool SudokuValidator(int[][] board)
        {
            return _codeWarsService.SudokuValidator(board);
        }
    }
}
