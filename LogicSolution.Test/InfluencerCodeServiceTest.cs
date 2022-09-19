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

        [Test]
        public void Test()
        {
            Assert.That(true);
        }
    }
}
