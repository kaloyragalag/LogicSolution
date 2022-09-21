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
    public class InfluencerCodeServiceTest
    {
        private IInfluencerCodeService _influencerCodeService { get; set; }

        [SetUp]
        public void Setup()
        {
            _influencerCodeService = new InfluencerCodeService();
        }

        #region DurationFormatted
        [Test]
        public void DurationFormatted_RandomSeconds_ReturnFormatted()
        {
            Assert.AreEqual("59 second(s)", _influencerCodeService.DurationFormatted(59));
            Assert.AreEqual("1 minute(s) 59 second(s)", _influencerCodeService.DurationFormatted(119));
            Assert.AreEqual("1 hour(s) 1 minute(s) 59 second(s)", _influencerCodeService.DurationFormatted(3719));
        }
        #endregion
        
        #region SumSmallestNumbers
        [Test]
        public void SumSmallestNumbers_RandomArrays_ReturnCorrect()
        {
            Assert.AreEqual(3, _influencerCodeService.SumSmallestNumbers(new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(13, _influencerCodeService.SumSmallestNumbers(new int[] { 6, 7, 8, 9, 10}));

            Assert.AreEqual(3, _influencerCodeService.SumSmallestNumbers(new int[] { 5, 4, 3, 2, 1 }));
            Assert.AreEqual(13, _influencerCodeService.SumSmallestNumbers(new int[] { 10, 9, 8, 7, 6 }));

            Assert.AreEqual(3, _influencerCodeService.SumSmallestNumbers(new int[] { 1, 3, 5, 4, 2 }));
            Assert.AreEqual(13, _influencerCodeService.SumSmallestNumbers(new int[] { 6, 8, 10, 9, 7 }));
        }
        #endregion

        #region CountSumNumbers
        [Test]
        public void CountSumNumbers_RandomArrays_ReturnCorrect()
        {
            Assert.AreEqual(new List<int>(new int[] { 5, 0 }), _influencerCodeService.CountSumNumbers(new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(new List<int>(new int[] { 0, -15 }), _influencerCodeService.CountSumNumbers(new int[] { -1, -2, -3, -4, -5 }));
            Assert.AreEqual(new List<int>(new int[] { 3, -3 }), _influencerCodeService.CountSumNumbers(new int[] { 5, 4, 3, -2, -1 }));
        }
        #endregion

        #region MoveZeroes
        [Test]
        public void MoveZeroes_RandomArrays_ReturnCorrect()
        {
            Assert.AreEqual(new List<int>(new int[] { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0 }), _influencerCodeService.MoveZeroes(new int[] { 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 }));
            Assert.AreEqual(new List<int>(new int[] { -5, -4, -3, -2, -1, 0, 0, 0, 0, 0 }), _influencerCodeService.MoveZeroes(new int[] { 0, 0, 0, 0, 0, -1, -2, -3, -4, -5 }));

            Assert.AreEqual(new List<int>(new int[] { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0 }), _influencerCodeService.MoveZeroes(new int[] { 1, 2, 3, 0, 0, 0, 0, 0, 4, 5 }));
            Assert.AreEqual(new List<int>(new int[] { -5, -4, -3, -2, -1, 0, 0, 0, 0, 0 }), _influencerCodeService.MoveZeroes(new int[] { -1, -2, -3, 0, 0, 0, 0, 0, -4, -5 }));
        }
        #endregion

        #region FindMissingNumber
        [Test]
        public void FindMissingNumber_RandomArrays_ReturnCorrect()
        {
            Assert.AreEqual(1, _influencerCodeService.FindMissingNumber(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
            Assert.AreEqual(10, _influencerCodeService.FindMissingNumber(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
            Assert.AreEqual(5, _influencerCodeService.FindMissingNumber(new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 }));


            Assert.AreEqual(1, _influencerCodeService.FindMissingNumber(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 }));
            Assert.AreEqual(10, _influencerCodeService.FindMissingNumber(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }));
            Assert.AreEqual(5, _influencerCodeService.FindMissingNumber(new int[] { 10, 9, 8, 7, 6, 4, 3, 2, 1 }));
        }
        #endregion

        #region IsSortedAndHow
        [Test]
        public void IsSortedAndHow_RandomArrays_ReturnCorrect()
        {
            Assert.AreEqual(new string[] { "YES", "ASCENDING" }, _influencerCodeService.IsSortedAndHow(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
            Assert.AreEqual(new string[] { "YES", "DESCENDING" }, _influencerCodeService.IsSortedAndHow(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 }));
            Assert.AreEqual(new string[] { "NO" }, _influencerCodeService.IsSortedAndHow(new int[] { 10, 1, 9, 8, 7, 6, 5, 4, 3, 2 }));

            Assert.AreEqual(new string[] { "YES", "DESCENDING" }, _influencerCodeService.IsSortedAndHow(new int[] { -2, -3, -4, -5, -6, -7, -8, -9, -10 }));
            Assert.AreEqual(new string[] { "YES", "ASCENDING" }, _influencerCodeService.IsSortedAndHow(new int[] { -10, -9, -8, -7, -6, -5, -4, -3, -2 }));
            Assert.AreEqual(new string[] { "NO" }, _influencerCodeService.IsSortedAndHow(new int[] { -10, -1, -9, -8, -7, -6, -5, -4, -3, -2 }));

            Assert.AreEqual(new string[] { "NA" }, _influencerCodeService.IsSortedAndHow(new int[] { 1 }));
        }
        #endregion

        #region SumMultiples
        [Test]
        public void SumMultiples_RandomNumbers_ReturnCorrect()
        {
            Assert.AreEqual(0, _influencerCodeService.SumMultiples(1));
            Assert.AreEqual(3, _influencerCodeService.SumMultiples(5));
            Assert.AreEqual(23, _influencerCodeService.SumMultiples(10));
            Assert.AreEqual(45, _influencerCodeService.SumMultiples(15));
            Assert.AreEqual(78, _influencerCodeService.SumMultiples(20));
        }
        #endregion

        #region DivideIntoOdd
        [Test]
        public void DivideIntoOdd_RandomNumbers_ReturnCorrect()
        {
            Assert.AreEqual(new int[] { 1 }, _influencerCodeService.DivideIntoOdd(1));
            Assert.AreEqual(new int[] { 1, 1 }, _influencerCodeService.DivideIntoOdd(2));
            Assert.AreEqual(new int[] { 3 }, _influencerCodeService.DivideIntoOdd(3));
            Assert.AreEqual(new int[] { 1, 3 }, _influencerCodeService.DivideIntoOdd(4));
            Assert.AreEqual(new int[] { 5 }, _influencerCodeService.DivideIntoOdd(5));
            Assert.AreEqual(new int[] { 3, 3 }, _influencerCodeService.DivideIntoOdd(6));
            Assert.AreEqual(new int[] { 7 }, _influencerCodeService.DivideIntoOdd(7));
            Assert.AreEqual(new int[] { 3, 5 }, _influencerCodeService.DivideIntoOdd(8));
            Assert.AreEqual(new int[] { 9 }, _influencerCodeService.DivideIntoOdd(9));
            Assert.AreEqual(new int[] { 5, 5 }, _influencerCodeService.DivideIntoOdd(10));
        }
        #endregion
    }
}
