using System;
using SimpleCalculator;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class ConstantsTests
    {
        [TestMethod]
        public void ConstantsCanBeInstantiated()
        {
            Constants cons = new Constants();
            Assert.IsNotNull(cons);
        }

        [TestMethod]
        public void ConstantsStoresConstants()
        {
            Constants cons = new Constants();
            int expected = 3;
            cons.Store("a", 3);
            int actual = cons.Retrieve("a");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ConstantsMustBeDefinedForUse()
        {
            Constants cons = new Constants();
            cons.Store("b", 5);
            int actual = cons.Retrieve("a");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstantsCannotBeRedefined()
        {
            Constants cons = new Constants();
            cons.Store("a", 3);
            cons.Store("a", 7);
        }

        [TestMethod]
        public void ConstantsAreCaseInsensitive()
        {
            Constants cons = new Constants();
            int expected = 7;
            cons.Store("A", 7);
            int actual = cons.Retrieve("a");
            Assert.AreEqual(expected, actual);
        }
    }
}
