using System.Collections.Generic;
using System;
using System.Linq;

namespace LogicSolution.Services
{
    public class InfluencerCodeService : IInfluencerCodeService
    {
        public string DurationFormatted(int seconds)
        {
            List<int> formattedTime = new List<int>();
            for (var i = 0; i < 3 && seconds > 0; i++)
            {
                if (seconds % 60 != 0)
                {
                    formattedTime.Add(seconds % 60);
                    seconds -= formattedTime[i];
                }
                else
                {
                    formattedTime.Add(0);
                }
                seconds /= 60;
            }

            var strFormattedTime = string.Empty;

            if (formattedTime.Count >= 3)
                strFormattedTime += formattedTime[2] + " hour(s) ";
            if (formattedTime.Count >= 2)
                strFormattedTime += formattedTime[1] + " minute(s) ";
            if (formattedTime.Count >= 1)
                strFormattedTime += formattedTime[0] + " second(s)";

            return strFormattedTime;
        }

        public int SumSmallestNumbers(int[] numbers)
        {
            if (numbers.Length >= 2)
            {
                int small1 = numbers[0], small2 = numbers[1];
                for (int i = 2; i < numbers.Length; i++)
                {
                    int currValue = numbers[i], tempValue = 0;
                    if (currValue < small1)
                    {
                        tempValue = small1;
                        small1 = currValue;
                        currValue = tempValue;
                    }
                    if (currValue < small2)
                    {
                        tempValue = small2;
                        small2 = currValue;
                        currValue = tempValue;
                    }
                }
                return small1 + small2;
            }
            else return 0;
        }

        public List<int> CountSumNumbers(int[] numbers)
        {
            int countPositive = 0, sumNegative = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                    countPositive++;
                else if (numbers[i] < 0)
                    sumNegative += numbers[i];
            }
            return new List<int>() { countPositive, sumNegative };
        }

        public int NextSmallest(int number)
        {
            List<int> separatedNum = new List<int>();

            int originalNum = number;
            for (int i = 0; number > 0; i++)
            {
                separatedNum.Add(number % 10);
                number /= 10;
            }

            List<int> possibleNum = new List<int>();
            for (int main = 0; main < separatedNum.Count; main++)
            {
                bool found = false;
                for (int j = main + 1; j < separatedNum.Count && separatedNum[j] > separatedNum[main] && !found; j++)
                {
                    int tempValue = separatedNum[j];
                    separatedNum[j] = separatedNum[main];
                    separatedNum[main] = tempValue;
                    found = true;
                }

                int newValue = 0, multiplier = 1;
                for (int i = 0; i < separatedNum.Count - 1; i++)
                {
                    multiplier *= 10;
                }

                for (int i = separatedNum.Count - 1; i >= 0; i--)
                {
                    newValue += separatedNum[i] * multiplier;
                    multiplier /= 10;
                }
                if (newValue < originalNum)
                    possibleNum.Add(newValue);
            }


            return possibleNum.IndexOf(0);
        }

        /// <summary>
        /// Takes an array of numbers as an argument. The function should move all zeroes to the end of the array
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Returns the modified array</returns>
        public int[] MoveZeroes(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    bool found = false;
                    for (int j = i + 1; !found && j < numbers.Length; j++)
                    {
                        if (numbers[j] != 0)
                        {
                            int tempVal = numbers[j];
                            numbers[j] = numbers[i];
                            numbers[i] = tempVal;
                            found = true;
                        }
                    }
                }
            }

            return numbers;
        }

        /// <summary>
        /// Takes an array of numbers as an arugment. The function will find and return the missing number between 1-10.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The missing number</returns>
        public int FindMissingNumber(int[] numbers)
        {
            int maxValue = 10;
            int sumAll = maxValue * (maxValue + 1) / 2;
            int sumNumbers = 0;

            for (int i = 0; i < maxValue - 1; i++)
            {
                sumNumbers += numbers[i];
            }

            return sumAll - sumNumbers;
        }

        /// <summary>
        /// Takes an array of numbers as an arugment. The function should check if the array is sorted and in which order.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The missing number</returns>
        public string[] IsSortedAndHow(int[] numbers)
        {
            if (numbers.Length > 1)
            {
                bool isSorted = true, isAscending = false;


                for (int i = 0; i < numbers.Length - 1 && isSorted; i++)
                {
                    if (i == 0)
                    {
                        isAscending = (numbers[i] < numbers[i + 1]);
                    }
                    else
                    {
                        if (isAscending)
                        {
                            isSorted = (numbers[i] < numbers[i + 1]);
                        }
                        else
                        {
                            isSorted = (numbers[i] > numbers[i + 1]);
                        }
                    }
                }

                if (isSorted)
                {
                    return new string[] { "YES", isAscending ? "ASCENDING" : "DESCENDING" };
                }
                else
                {
                    return new string[] { "NO" };
                }
            }
            else
            {
                return new string[] { "NA" };
            }
        }

        /// <summary>
        /// Takes a number as parameter. Sum all positive numbers smaller than the given number divisible by 5 or 3
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int SumMultiples(int number)
        {
            int sum = 0;
            do
            {
                number--;
                if (number % 5 == 0 || number % 3 == 0)
                {
                    sum += number;
                }
            } while (number > 0);

            return sum;
        }

        /// <summary>
        /// If the number is even, divide it into two closest odd numbers (which by summing it returns to the even number)
        /// If the number passed by parameter is odd, return the number itself within a one-position array.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int[] DivideIntoOdd(int number)
        {
            if (number % 2 == 0)
            {
                int bottom = 0, top = 0;
                int middle = number / 2;
                for (int i = middle; bottom == 0 && i > 0; i--)
                {
                    for (int j = middle; top == 0 && j < number; j++)
                    {
                        if (i % 2 != 0 && j % 2 != 0)
                        {
                            if (i + j == number)
                            {
                                bottom = i;
                                top = j;
                            }
                        }
                    }
                }

                return new int[] { bottom, top };
            }
            else
            {
                return new int[] { number };
            }
        }

        /// <summary>
        /// The function must calculate parameter 1, raised to the power of parameter 2, and return the last digit of the resulting value.
        /// </summary>
        /// <param name="baseNum">Base Number</param>
        /// <param name="powerNum">Power</param>
        /// <returns>Return the last digit of the resulting value</returns>
        public double LastDigit(double baseNum, double powerNum)
        {
            double lastDigit = 0;

            lastDigit = Math.Pow(baseNum, powerNum);

            return lastDigit % 10;
        }

        /// <summary>
        /// The function must count characters, words and lines, returning an object with these values.
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public string PhraseParser(string phrase)
        {
            int characters = 0, words = 0, lines = 0;

            lines = phrase.Split(Environment.NewLine.ToString()).Length;

            words = phrase.Split(Environment.NewLine.ToString()).Sum(x => x.Split(" ").Length);

            characters = phrase.Length;

            return string.Format("Characters: {0}, Words: {1}, Lines: {2}", characters, words, lines);
        }
    }
}
