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
            string expected = "3";
            string actual = Evaluate.Eval(Parse.Convert("1 + 2"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateSubractionSubtracts()
        {
            string expected = "-3";
            string actual = Evaluate.Eval(Parse.Convert("-2-1"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateMultiplicationMultiplies()
        {
            string expected = "20";
            string actual = Evaluate.Eval(Parse.Convert("5 * 4"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateDivideDivides()
        {
            string expected = "3";
            string actual = Evaluate.Eval(Parse.Convert("12 / 4"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateModuloModulos()
        {
            string expected = "2";
            string actual = Evaluate.Eval(Parse.Convert("14 % 3"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void EvaluateErrorsWithInvalidInput()
        {
            string actual = Evaluate.Eval(Parse.Convert("5 / 0"));
        }

        [TestMethod]
        public void EvaluateHandlesComplicatedValidInput()
        {
            string expected = "-225";
            string actual = Evaluate.Eval(Parse.Convert("-212 - +13"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateHandlesOtherComplicatedValidInput()
        {
            string expected = "225";
            string actual = Evaluate.Eval(Parse.Convert("212--13"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateSetsStackLastE()
        {
            string expected = "3 + 4";
            Evaluate.Eval(Parse.Convert("3+4"));
            string actual = Stack.LastE;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateSetsStackLast()
        {
            string expected = "7";
            Evaluate.Eval(Parse.Convert("3+4"));
            string actual = Stack.Last;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateImplementsStackLast()
        {
            string expected = "7";
            Evaluate.Eval(Parse.Convert("3+4"));
            string actual = Evaluate.Eval(Parse.Convert("Last"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateImplementsStackLastE()
        {
            string expected = "-7 + 12";
            Evaluate.Eval(Parse.Convert("-7+12"));
            string actual = Evaluate.Eval(Parse.Convert("LastE"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateImplementsConstants()
        {
            string expected = "7";
            Evaluate.Eval(Parse.Convert("A = 3"));
            string actual = Evaluate.Eval(Parse.Convert("a + 4"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateCanUseConstantsToDefineConstants()
        {
            string expected = "14";
            Evaluate.Eval(Parse.Convert("b = 7"));
            Evaluate.Eval(Parse.Convert("c = b"));
            string actual = Evaluate.Eval(Parse.Convert("C + 7"));
            Assert.AreEqual(expected, actual);
        }
    }
}
