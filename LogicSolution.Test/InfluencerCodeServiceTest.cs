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

        #region SumSmallestNumbers
        [Test]
        public void CountSumNumbers_RandomArrays_ReturnCorrect()
        {
            Assert.AreEqual(new List<int>(new int[] { 5, 0 }), _influencerCodeService.CountSumNumbers(new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(new List<int>(new int[] { 0, -15 }), _influencerCodeService.CountSumNumbers(new int[] { -1, -2, -3, -4, -5 }));
            Assert.AreEqual(new List<int>(new int[] { 3, -3 }), _influencerCodeService.CountSumNumbers(new int[] { 5, 4, 3, -2, -1 }));
        }
        #endregion
    }
}
