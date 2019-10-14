using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TREDS.Virginia.Gov.QA.TDD.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            int a = 10;
                int b = 10;
            Assert.AreEqual(a, b);
            Console.Write("Hello World");

        }
    }
}
