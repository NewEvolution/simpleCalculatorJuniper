using System;
using SimpleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class ParseTests
    {
        [TestMethod]
        public void ParseCanBeInstantiated()
        {
            Parse parser = new Parse();
            Assert.IsNotNull(parser);
        }

        [TestMethod]
        public void ParseHasConvertMethodThatTakesStringAndReturnsCharArray()
        {
            Parse parser = new Parse();
            string[] actual = parser.Convert("1 + 2");
            string[] expected = new string[] { "1", "+", "2" };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseConvertThowsErrorWithIncompleteInput()
        {
            Parse parser = new Parse();
            string[] actual = parser.Convert("1 +");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseConvertThowsErrorWithExtraInput()
        {
            Parse parser = new Parse();
            string[] actual = parser.Convert("1 + 1 - 4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseConvertThrowsErrorWithInvalidFirstArgument()
        {
            Parse parser = new Parse();
            string[] actual = parser.Convert("1b + 1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseConvertThrowsErrorWithInvalidLastArgument()
        {
            Parse parser = new Parse();
            string[] actual = parser.Convert("1 + cc");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseConvertThrowsErrorWithInvalidOperator()
        {
            Parse parser = new Parse();
            string[] actual = parser.Convert("1 # 1");
        }

        [TestMethod]
        public void ParseConvertAcceptsSingleLetterArguments()
        {
            Parse parser = new Parse();
            string[] expected = new string[] { "1", "+", "c" };
            string[] actual = parser.Convert("1 + c");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseConvertAcceptsLargerNumberArguments()
        {
            Parse parser = new Parse();
            string[] expected = new string[] { "g", "+", "235" };
            string[] actual = parser.Convert("g + 235");
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
