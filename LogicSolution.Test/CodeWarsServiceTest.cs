using LogicSolution.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicSolution.Test
{
    [TestFixture]
    public class CodeWarsServiceTest
    {
        private ICodeWarsService _codeWarsService;
        [SetUp]
        public void Setup()
        {
            _codeWarsService = new CodeWarsService();
        }

        #region GetVowelCount
        [Test]
        public void GetVowelCount_RandomText_ReturnCorrect()
        {
            Assert.AreEqual(5, _codeWarsService.GetVowelCount("abracadabra"), "Nope!");
            Assert.AreEqual(5, _codeWarsService.GetVowelCount("abcdefghijklmnopqrstuvwxyz"), "Nope!");
        }

        [Test]
        public void GetVowelCount_EmptyText_ReturnCorrect()
        {
            Assert.AreEqual(0, _codeWarsService.GetVowelCount(""), "Nope!");
        } 
        #endregion

        #region OpenOrSenior
        [Test]
        public void OpenOrSenior_RandomArray_ReturnCorrect()
        {
            Assert.AreEqual(new[] { "Open", "Senior", "Open", "Senior" }, _codeWarsService.OpenOrSenior(new[] { new[] { 45, 12 }, new[] { 55, 21 }, new[] { 19, 2 }, new[] { 104, 20 } }));
            Assert.AreEqual(new[] { "Open", "Open", "Open", "Open" }, _codeWarsService.OpenOrSenior(new[] { new[] { 3, 12 }, new[] { 55, 1 }, new[] { 91, -2 }, new[] { 54, 23 } }));
            Assert.AreEqual(new[] { "Senior", "Open", "Open", "Open" }, _codeWarsService.OpenOrSenior(new[] { new[] { 59, 12 }, new[] { 45, 21 }, new[] { -12, -2 }, new[] { 12, 12 } }));
        } 
        #endregion

        #region TwoToOneLongest
        [Test]
        public void TwoToOneLongest_RandomTexts_ReturnCorrect()
        {
            Assert.AreEqual("aehrsty", _codeWarsService.TwoToOneLongest("aretheyhere", "yestheyarehere"));
            Assert.AreEqual("abcdefghilnoprstu", _codeWarsService.TwoToOneLongest("loopingisfunbutdangerous", "lessdangerousthancoding"));
            Assert.AreEqual("acefghilmnoprstuy", _codeWarsService.TwoToOneLongest("inmanylanguages", "theresapairoffunctions"));
        } 
        #endregion

        #region BreakCamelCase
        [Test]
        public void BreakCamelCase_RandomText_ReturnCorrectFormat()
        {
            Assert.AreEqual("camel Case", _codeWarsService.BreakCamelCase("camelCase"));
            Assert.AreEqual("hello World", _codeWarsService.BreakCamelCase("helloWorld"));
        }

        [Test]
        public void BreakCamelCase_HasLeadingSpaceText_ReturnCorrectFormat()
        {
            Assert.AreEqual("camel Case", _codeWarsService.BreakCamelCase(" camelCase"));
            Assert.AreEqual("hello World", _codeWarsService.BreakCamelCase("helloWorld "));
        }
        #endregion

        #region Anagrams
        [Test]
        public void Anagrams_RandomText_ReturnValid()
        {
            Assert.AreEqual(new List<string> { "a" }, _codeWarsService.Anagrams("a", new List<string> { "a", "b", "c", "d" }));
            Assert.AreEqual(new List<string> { "carer", "arcre", "carre" }, _codeWarsService.Anagrams("racer", new List<string> { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" }));
        }
        #endregion

        #region Rot13
        [Test, Description("test")]
        public void Rot13_LowerCapsText_ReturnCorrect()
        {
            Assert.AreEqual("grfg", _codeWarsService.Rot13("test"), String.Format("Input: test, Expected Output: grfg, Actual Output: {0}", _codeWarsService.Rot13("test")));
        }

        [Test, Description("Test")]
        public void Rot13_HasUpperCapsText_ReturnCorrect()
        {
            Assert.AreEqual("Grfg", _codeWarsService.Rot13("Test"), String.Format("Input: Test, Expected Output: Grfg, Actual Output: {0}", _codeWarsService.Rot13("Test")));
        }

        [Test, Description("abcdefghijklmnopqrstuvwxyz")]
        public void Rot13_AllAlphabet_ReturnCorrect()
        {
            Assert.AreEqual("nopqrstuvwxyzabcdefghijklm", _codeWarsService.Rot13("abcdefghijklmnopqrstuvwxyz"), String.Format("Input: abcdefghijklmnopqrstuvwxyz, Expected Output: nopqrstuvwxyzabcdefghijklm, Actual Output: {0}", _codeWarsService.Rot13("Test")));
        }

        [Test, Description("C# is cool!")]
        public void Rot13_HasSpecialCharText_ReturnCorrect()
        {
            Assert.AreEqual("P# vf pbby!", _codeWarsService.Rot13("C# is cool!"), String.Format("Input: C# is cool!, Expected Output: P# vf pbby!, Actual Output: {0}", _codeWarsService.Rot13("Test")));
        }

        [Test, Description("10+2 is twelve.")]
        public void Rot13_HasNumericText_ReturnCorrect()
        {
            Assert.AreEqual("10+2 vf gjryir.", _codeWarsService.Rot13("10+2 is twelve."), String.Format("Input: 10+2 is twelve., Expected Output: 10+2 vf gjryir., Actual Output: {0}", _codeWarsService.Rot13("Test")));
        }
        #endregion

        #region IsPangram
        [Test]
        public void IsPangram_RandomTexts_IsValid()
        {
            Assert.That(_codeWarsService.IsPangram("The quick brown fox jumps over the lazy dog."));
            Assert.That(_codeWarsService.IsPangram("Pack my box with five dozen liquor jugs."));
            Assert.That(_codeWarsService.IsPangram("How quickly daft jumping zebras vex."));
            Assert.That(_codeWarsService.IsPangram("Raw Danger! (Zettai Zetsumei Toshi 2) for the PlayStation 2 is a bit queer, but an alright game I guess, uh... CJ kicks and vexes Tenpenny precariously? This should be a pangram now, probably."));
        }
        [Test]
        public void IsPangram_RandomTexts_IsNotValid()
        {
            Assert.That(!_codeWarsService.IsPangram("A pangram is a sentence that contains every single letter of the alphabet at least once"));
        }

        [Test]
        public void IsPangram_NotSortedAlphabets_IsValid()
        {
            Assert.That(_codeWarsService.IsPangram("AbCdEfGhIjKlM zYxWvUtSrQpOn"));
        }

        [Test]
        public void IsPangram_SortedAlphabets_IsValid()
        {
            Assert.That(_codeWarsService.IsPangram("abcdefghijklmnopqrstuvwxyz "));
        }

        [Test]
        public void IsPangram_TextWithNumbers_IsValid()
        {
            Assert.That(_codeWarsService.IsPangram("ABCD45EFGH,IJK,LMNOPQR56STUVW3XYZ"));
        }
        #endregion

        #region AlphabetPosition
        [Test]
        public void AlphabetPosition_RandomTexts_ReturnCorrect()
        {
            Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", _codeWarsService.AlphabetPosition("The sunset sets at twelve o' clock."));
            Assert.AreEqual("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", _codeWarsService.AlphabetPosition("The narwhal bacons at midnight."));
        }
        #endregion

        #region FindMissingLetter
        [Test]
        public void FindMissingLetter_RandomArray_ReturnCorrect()
        {
            Assert.AreEqual('e', _codeWarsService.FindMissingLetter(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', _codeWarsService.FindMissingLetter(new[] { 'O', 'Q', 'R', 'S' }));
        }
        #endregion

        #region RGBToHex
        [Test]
        public void RGBToHex_RandomRGB_ReturnCorrect()
        {
            Assert.AreEqual("FFFFFF", _codeWarsService.RGBToHex(255, 255, 255));
            Assert.AreEqual("FFFFFF", _codeWarsService.RGBToHex(255, 255, 300));
            Assert.AreEqual("000000", _codeWarsService.RGBToHex(0, 0, 0));
            Assert.AreEqual("9400D3", _codeWarsService.RGBToHex(148, 0, 211));
            Assert.AreEqual("9400D3", _codeWarsService.RGBToHex(148, -20, 211), "Handle negative numbers.");
            Assert.AreEqual("90C3D4", _codeWarsService.RGBToHex(144, 195, 212));
            Assert.AreEqual("D4350C", _codeWarsService.RGBToHex(212, 53, 12), "Consider single hex digit numbers.");
        }
        #endregion

        #region TicTacToeChecker
        [Test]
        public void TicTacToeChecker_HorizontalCheck_ReturnWinner()
        {
            Assert.AreEqual(1, _codeWarsService.TicTacToeChecker(new int[,] { { 1, 1, 1 }
                                                                           , { 0, 2, 2 }
                                                                           , { 0, 0, 0 } }));

            Assert.AreEqual(1, _codeWarsService.TicTacToeChecker(new int[,] { { 0, 2, 2 }
                                                                           , { 1, 1, 1 }
                                                                           , { 0, 0, 0 } }));

            Assert.AreEqual(1, _codeWarsService.TicTacToeChecker(new int[,] { { 0, 2, 2 }
                                                                           , { 0, 0, 0 }
                                                                           , { 1, 1, 1 } }));

            Assert.AreEqual(2, _codeWarsService.TicTacToeChecker(new int[,] { { 2, 2, 2 }
                                                                           , { 0, 1, 1 }
                                                                           , { 0, 0, 0 } }));

            Assert.AreEqual(2, _codeWarsService.TicTacToeChecker(new int[,] { { 0, 1, 1 }
                                                                           , { 2, 2, 2 }
                                                                           , { 0, 0, 0 } }));

            Assert.AreEqual(2, _codeWarsService.TicTacToeChecker(new int[,] { { 0, 1, 1 }
                                                                           , { 0, 0, 0 }
                                                                           , { 2, 2, 2 } }));
        }

        [Test]
        public void TicTacToeChecker_VerticalCheck_ReturnWinner()
        {
            Assert.AreEqual(1, _codeWarsService.TicTacToeChecker(new int[,] { { 1, 0, 1 }
                                                                           , { 1, 2, 2 }
                                                                           , { 1, 0, 0 } }));

            Assert.AreEqual(1, _codeWarsService.TicTacToeChecker(new int[,] { { 2, 1, 1 }
                                                                           , { 0, 1, 2 }
                                                                           , { 2, 1, 0 } }));

            Assert.AreEqual(1, _codeWarsService.TicTacToeChecker(new int[,] { { 2, 2, 1 }
                                                                           , { 0, 1, 1 }
                                                                           , { 0, 1, 1 } }));

            Assert.AreEqual(2, _codeWarsService.TicTacToeChecker(new int[,] { { 2, 0, 2 }
                                                                           , { 2, 1, 1 }
                                                                           , { 2, 0, 0 } }));

            Assert.AreEqual(2, _codeWarsService.TicTacToeChecker(new int[,] { { 1, 2, 2 }
                                                                           , { 0, 2, 1 }
                                                                           , { 1, 2, 0 } }));

            Assert.AreEqual(2, _codeWarsService.TicTacToeChecker(new int[,] { { 1, 1, 2 }
                                                                           , { 0, 2, 2 }
                                                                           , { 0, 2, 2 } }));
        }

        [Test]
        public void TicTacToeChecker_DiagonalCheck_ReturnWinner()
        {
            Assert.AreEqual(1, _codeWarsService.TicTacToeChecker(new int[,] { { 2, 0, 1 }
                                                                           , { 1, 1, 2 }
                                                                           , { 1, 0, 0 } }));

            Assert.AreEqual(1, _codeWarsService.TicTacToeChecker(new int[,] { { 1, 2, 1 }
                                                                           , { 0, 1, 2 }
                                                                           , { 0, 1, 1 } }));

            Assert.AreEqual(2, _codeWarsService.TicTacToeChecker(new int[,] { { 1, 0, 2 }
                                                                           , { 2, 2, 1 }
                                                                           , { 2, 0, 0 } }));

            Assert.AreEqual(2, _codeWarsService.TicTacToeChecker(new int[,] { { 2, 1, 2 }
                                                                           , { 0, 2, 1 }
                                                                           , { 0, 2, 2 } }));
        }

        [Test]
        public void TicTacToeChecker_NoWinnerCheck_ReturnZero()
        {
            Assert.AreEqual(0, _codeWarsService.TicTacToeChecker(new int[,] { { 2, 1, 1 }
                                                                           , { 1, 2, 2 }
                                                                           , { 1, 2, 1 } }));
        }

        [Test]
        public void TicTacToeChecker_IncompleteBoard_ReturnNegativeOne()
        {
            Assert.AreEqual(-1, _codeWarsService.TicTacToeChecker(new int[,] { { 0, 1, 1 }
                                                                            , { 1, 2, 2 }
                                                                            , { 1, 2, 1 } }));
        }
        #endregion

        #region PigLatin
        [Test]
        public void PigLatin_RandomTexts_ReturnCorrect()
        {
            Assert.AreEqual("igPay atinlay siay oolcay", _codeWarsService.PigLatin("Pig latin is cool"));
            Assert.AreEqual("hisTay siay ymay tringsay", _codeWarsService.PigLatin("This is my string"));
        }
        #endregion

        #region SudokuValidator
        [Test]
        public void SudokuValidator_RandomBoard_ReturnValid()
        {
            Assert.That(_codeWarsService.SudokuValidator(new int[][]{
                new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
            }));
        }

        [Test]
        public void SudokuValidator_RandomBoard_ReturnNotValid()
        {
            Assert.That(!_codeWarsService.SudokuValidator(new int[][]{
                new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                new int[] {1, 9, 8, 3, 0, 2, 5, 6, 7},
                new int[] {8, 5, 0, 7, 6, 1, 4, 2, 3},
                new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                new int[] {7, 0, 3, 9, 2, 4, 8, 5, 6},
                new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                new int[] {3, 0, 0, 2, 8, 6, 1, 7, 9},
            }));
        } 
        #endregion
    }
}
