using System;
using SimpleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class ParseTests
    {
        [TestMethod]
        public void ParseHasConvertMethodThatTakesStringAndReturnsCharArray()
        {
            string[] actual = Parse.Convert("1 + 2");
            string[] expected = new string[] { "1", "+", "2" };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseThowsErrorWithIncompleteInput()
        {
            string[] actual = Parse.Convert("1 +");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseThowsErrorWithExtraInput()
        {
            string[] actual = Parse.Convert("1 + 1 - 4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseThrowsErrorWithInvalidFirstArgument()
        {
            string[] actual = Parse.Convert("1b + 1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseThrowsErrorWithInvalidLastArgument()
        {
            string[] actual = Parse.Convert("1 + cc");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseThrowsErrorWithInvalidOperator()
        {
            string[] actual = Parse.Convert("1 # 1");
        }

        [TestMethod]
        public void ParseAcceptsSingleLetterArguments()
        {
            string[] expected = new string[] { "1", "+", "c" };
            string[] actual = Parse.Convert("1 + c");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseAcceptsLargerNumberArguments()
        {
            string[] expected = new string[] { "g", "+", "235" };
            string[] actual = Parse.Convert("g + 235");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseNoSpacesWorks()
        {
            string[] expected = new string[] { "g", "+", "235" };
            string[] actual = Parse.Convert("g+235");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseNegativesWorks()
        {
            string[] expected = new string[] { "-g", "+", "-235" };
            string[] actual = Parse.Convert("-g+-235");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseTooManyOperandsBreaks()
        {
            string[] actual = Parse.Convert("-g---235");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseWeirdlyPlacedSpacesBreaks()
        {
            string[] actual = Parse.Convert("4 - - 235");
        }
    }
}
