using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicSolution.Services
{
    public class CodeWarsService : ICodeWarsService
    {
        public string BreakCamelCase(string camelCaseText)
        {
            return String.Join("", camelCaseText.Select(x => Char.IsUpper(x) ? string.Format(" {0}", x) : x.ToString())).Trim();
        }

        public List<string> Anagrams(string word, List<string> words)
        {
            return words.Where(x => String.Join("", x.OrderBy(y => y)) == String.Join("", word.OrderBy(x => x))).ToList();
        }

        public string Rot13(string message)
        {
            string strRot13 = string.Empty;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            foreach (char letter in message)
            {
                alphabet = Char.IsUpper(letter) ? alphabet.ToUpper() : alphabet.ToLower();
                if (alphabet.IndexOf(letter) >= 0)
                {
                    if (alphabet.IndexOf(letter) + 13 >= 26)
                    {
                        strRot13 += alphabet[alphabet.IndexOf(letter) + 13 - 26];
                    }
                    else
                    {
                        strRot13 += alphabet[alphabet.IndexOf(letter) + 13];
                    }
                }
                else
                {
                    strRot13 += letter;
                }
            }

            return strRot13;
        }

        public bool IsPangram(string text)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            text = String.Join("", text.ToLower().Where(x => (int)x >= 97 && (int)x <= 122).ToHashSet().OrderBy(x => x));
            return alphabet == text;
        }

        public string AlphabetPosition(string text)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string strAlphaPos = String.Join(" ", text.ToLower().Where(x => Char.IsLetter(x)).Select(x => alphabet.IndexOf(x) + 1));
            return strAlphaPos;
        }

        public char FindMissingLetter(char[] array)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char strMissing = ' ';
            if (array.Length > 0)
            {
                alphabet = Char.IsUpper(array[0]) ? alphabet.ToUpper() : alphabet;
                int firstIndex = alphabet.IndexOf(array[0]);
                strMissing = array.Where(x => x != alphabet[firstIndex++]).FirstOrDefault();
            }

            return (char)((int)strMissing - 1);
        }

        public string RGBToHex(int r, int g, int b)
        {
            string strHex = string.Empty;

            strHex += Hex(r);
            strHex += Hex(g);
            strHex += Hex(b);

            return strHex;
        }

        private string Hex(int color)
        {
            color = color < 0 ? 0 : color;
            color = color > 255 ? 255 : color;

            double mainColor = Math.Truncate((double)color / 16);
            double remColor = ((double)color / 16 - mainColor) * 16;
            string strR = string.Empty;

            foreach (double colors in new double[] { mainColor, remColor })
            {
                if (colors > 9)
                    strR += ((char)(87 + colors)).ToString().ToUpper();
                else
                    strR += colors.ToString();
            }

            return strR;
        }

        public int TicTacToeChecker(int[,] board)
        {
            string rowBoard = string.Empty, columnBoard = string.Empty, diagonalBoard = string.Empty, diagonalBackBoard = string.Empty;
            bool hasZero = false;
            List<string> lstBoard = new List<string>();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    rowBoard += board[i, j];
                    columnBoard += board[j, i];
                    if(!hasZero && board[i, j] == 0)
                        hasZero = true;
                }
                diagonalBoard += board[i, i];
                diagonalBackBoard += board[i, board.GetLength(0) - 1 - i];

                lstBoard.Add(rowBoard);
                lstBoard.Add(columnBoard);
                columnBoard = rowBoard = String.Empty;
            }
            lstBoard.Add(diagonalBoard);
            lstBoard.Add(diagonalBackBoard);

            if (lstBoard.Contains("111"))
                return 1;
            else if (lstBoard.Contains("222"))
                return 2;
            else if (hasZero)
                    return -1;
            else return 0;
        }

        public string PigLatin(string word)
        {
            return string.Join(" ", word.Split(" ").Select(x => x.Any(y => Char.IsPunctuation(y)) ? x : string.Format("{0}{1}ay", x.Substring(1), x[0])));
        }

        public bool SudokuValidator(int[][] board)
        {
            int MINIBOARD = 3;
            string rowBoard = string.Empty, columnBoard = string.Empty, miniBoard1 = String.Empty, miniBoard2 = String.Empty, miniBoard3 = String.Empty;
            bool hasZero = false;
            List<string> lstBoard = new List<string>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    rowBoard += board[i][j];
                    columnBoard += board[j][i];
                    if (!hasZero && board[i][j] == 0)
                        hasZero = true;
                }
                if ((i + 1) % 3 == 1)
                {
                    for (int k = i; (k - i) < MINIBOARD; k++)
                    {
                        for (int l = 0; l < MINIBOARD; l++)
                        {
                            miniBoard1 += board[k][l];
                            miniBoard2 += board[k][l + 3];
                            miniBoard3 += board[k][l + 6];
                        }
                    }
                    lstBoard.Add(String.Join("", miniBoard1.OrderBy(x => x)));
                    lstBoard.Add(String.Join("", miniBoard2.OrderBy(x => x)));
                    lstBoard.Add(String.Join("", miniBoard3.OrderBy(x => x)));
                    miniBoard1 = miniBoard2 = miniBoard3 = String.Empty;
                }

                lstBoard.Add(String.Join("", rowBoard.OrderBy(x => x)));
                lstBoard.Add(String.Join("", columnBoard.OrderBy(x => x)));
                columnBoard = rowBoard = String.Empty;
            }

            bool isValid = lstBoard.All(x => x == "123456789");

            return hasZero ? false : isValid;
        }
    }
}
