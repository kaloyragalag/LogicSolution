using System.Collections.Generic;
using System;
using System.Linq;
using LogicSolution.Model;

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

        public int[] MoveZeroes(int[] numbers)
        {
            int[] numberZero = numbers.Where(x => x == 0).ToArray();
            int[] numberNotZero = numbers.Where(x => x != 0).OrderBy(y => y).ToArray();

            return numberNotZero.Concat(numberZero).ToArray();
        }

        public int FindMissingNumber(int[] numbers)
        {
            int[] allNum = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            return allNum.FirstOrDefault(x => !numbers.Contains(x));
        }

        public string[] IsSortedAndHow(int[] numbers)
        {
            if (numbers.Length > 1)
            {
                int[] sortedAsc = numbers.OrderBy(x => x).ToArray();
                int[] sortedDesc = numbers.OrderByDescending(x => x).ToArray();

                if (sortedAsc.SequenceEqual(numbers))
                {
                    return new string[] { "YES", "ASCENDING" };
                }
                else if (sortedDesc.SequenceEqual(numbers))
                {
                    return new string[] { "YES", "DESCENDING" };
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

        public double[] PowerLastDigit(double baseNum, double powerNum)
        {
            double lastDigit = 0;

            lastDigit = Math.Pow(baseNum, powerNum);

            return new double[] { lastDigit, lastDigit % 10 };
        }

        public PhraseParser PhraseParser(string phrase)
        {
            int characters = 0, words = 0, lines = 0;

            lines = phrase.Split(Environment.NewLine.ToString()).Length;

            words = phrase.Split(Environment.NewLine.ToString()).Sum(x => x.Split(" ").Length);

            characters = phrase.Length;

            return new PhraseParser() { Characters = characters, Words = words, Lines = lines };
        }
    }
}
