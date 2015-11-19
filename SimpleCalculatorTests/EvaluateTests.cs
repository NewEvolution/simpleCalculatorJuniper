using System;
using SimpleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class EvaluateTests
    {
        [TestMethod]
        public void EvaluateAdditionAdds()
        {
            int expected = 3;
            int actual = Evaluate.Eval(Parse.Convert("1 + 2"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateSubractionSubtracts()
        {
            int expected = -3;
            int actual = Evaluate.Eval(Parse.Convert("-2-1"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateMultiplicationMultiplies()
        {
            int expected = 20;
            int actual = Evaluate.Eval(Parse.Convert("5 * 4"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateDivideDivides()
        {
            int expected = 3;
            int actual = Evaluate.Eval(Parse.Convert("12 / 4"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateModuloModulos()
        {
            int expected = 2;
            int actual = Evaluate.Eval(Parse.Convert("14 % 3"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void EvaluateErrorsWithInvalidInput()
        {
            int actual = Evaluate.Eval(Parse.Convert("5 / 0"));
        }

        [TestMethod]
        public void EvaluateHandlesComplicatedValidInput()
        {
            int expected = -225;
            int actual = Evaluate.Eval(Parse.Convert("-212 - +13"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateHandlesOtherComplicatedValidInput()
        {
            int expected = 225;
            int actual = Evaluate.Eval(Parse.Convert("212--13"));
            Assert.AreEqual(expected, actual);
        }
    }
}
