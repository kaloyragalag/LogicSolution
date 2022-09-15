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
        private ICodeWarsService codeWarsService;
        [SetUp]
        public void Setup()
        {
            codeWarsService = new CodeWarsService();
        }
    }
}
