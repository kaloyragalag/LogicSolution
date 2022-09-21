using LogicSolution.Model;
using System.Collections.Generic;

namespace LogicSolution.Services
{
    public interface IInfluencerCodeService
    {
        string DurationFormatted(int seconds);
        int SumSmallestNumbers(int[] numbers);
        List<int> CountSumNumbers(int[] numbers);
        int[] MoveZeroes(int[] numbers);
        int FindMissingNumber(int[] numbers);
        string[] IsSortedAndHow(int[] numbers);
        int SumMultiples(int number);
        int[] DivideIntoOdd(int number);
        double[] PowerLastDigit(double baseNum, double powerNum);
        PhraseParser PhraseParser(string phrase);
    }
}
