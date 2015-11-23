using System;
using SimpleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void StackStoresAnExpression()
        {
            string expected = "3 + 4";
            Stack.LastE = "3 + 4";
            Assert.AreEqual(expected, Stack.LastE);
        }

        [TestMethod]
        public void StackStoresAResult()
        {
            string expected = "7";
            Stack.Last = "7";
            Assert.AreEqual(expected, Stack.Last);
        }
    }
}
