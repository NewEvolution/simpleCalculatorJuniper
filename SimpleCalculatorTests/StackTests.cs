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
            string[] expected = new string[3] { "3", "+", "4" };
            Stack.LastE = new string[3] { "3", "+", "4" };
            CollectionAssert.AreEqual(expected, Stack.LastE);
        }

        [TestMethod]
        public void StackStoresAResult()
        {
            int expected = 7;
            Stack.Last = 7;
            Assert.AreEqual(expected, Stack.Last);
        }
    }
}
