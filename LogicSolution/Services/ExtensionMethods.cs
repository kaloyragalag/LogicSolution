using System.Collections.Generic;
using System;
using System.Linq;
using LogicSolution.Model;
using System.ComponentModel;
using System.Reflection;

namespace LogicSolution.Services
{
    public static class ExtensionMethods
    {
        #region MorseDictionary
        private static Dictionary<string, string> morseList = new Dictionary<string, string>() {
            {"...---...", "SOS"},
            {".-", "A"},
            {"-...", "B"},
            {"-.-.", "C"},
            {"-..", "D"},
            {".", "E"},
            {"..-.", "F"},
            {"--.", "G"},
            {"....", "H"},
            {"..", "I"},
            {".---", "J"},
            {"-.-", "K"},
            {".-..", "L"},
            {"--", "M"},
            {"-.", "N"},
            {"---", "O"},
            {".--.", "P"},
            {"--.-", "Q"},
            {".-.", "R"},
            {"...", "S"},
            {"-", "T"},
            {"..-", "U"},
            {"...-", "V"},
            {".--", "W"},
            {"-..-", "X"},
            {"-.--", "Y"},
            {"--..", "Z"},
            {".----", "1"},
            {"..---", "2"},
            {"...--", "3"},
            {"....-", "4"},
            {".....", "5"},
            {"-....", "6"},
            {"--...", "7"},
            {"---..", "8"},
            {"----.", "9"},
            {"-----", "0"},
            {".-.-.-", "."},
            {"-.-.--", "!" }
        }; 
        #endregion

        public static T[,] To2DArray<T>(this IList<T[]> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            int max = source.Select(l => l).Max(l => l.Count());

            var result = new T[source.Count, max];

            for (int i = 0; i < source.Count; i++)
            {
                for (int j = 0; j < source[i].Count(); j++)
                {
                    result[i, j] = source[i][j];
                }
            }

            return result;
        }

        public static string GetMorse(this string morse)
        {
            string morseValue;
            morseList.TryGetValue(morse, out morseValue);
            return morseValue;
        }

        public static bool PhraseCheck(this PhraseParser x, PhraseParser y)
        {
            return x.Characters == y.Characters && x.Words == y.Words && x.Lines == y.Lines;
        }
    }
}
