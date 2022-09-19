using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicSolution.Services
{
    public interface ICodeWarsService
    {
        public string TwoToOneLongest(string s1, string s2);
        string BreakCamelCase(string camelCaseText);
        List<string> Anagrams(string word, List<string> words);
        string Rot13(string message);
        bool IsPangram(string text);
        string AlphabetPosition(string text);
        char FindMissingLetter(char[] array);
        string RGBToHex(int r, int g, int b);
        int TicTacToeChecker(int[,] board);
        string PigLatin(string word);
        bool SudokuValidator(int[][] board);
    }
}
