using System;
using Xunit;

namespace StringCalculatorTest
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int res = Lab1.StringCalculator.CalculateString("");
            Assert.Equal(0, res);
        }

        [Theory]
        [InlineData("25", 25)]
        public void SingleNumberReturnsNumber(string s, int expected)
        {
            int res = Lab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25,15", 40)]
        [InlineData("25\n15", 40)]
        [InlineData("2,15", 17)]
        public void DoubleNumbersReturnsNumber(string s, int expected)
        {
            int res = Lab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25,15\n0", 40)]
        [InlineData("25\n15\n12", 52)]
        [InlineData("6\n2,15", 23)]
        public void TripleNumbersReturnsNumber(string s, int expected)
        {
            int res = Lab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("-25,15\n0")]
        [InlineData("-12")]
        [InlineData("6\n-5")]
        public void NegativeNumbersThrowsException(string s)
        {
            _ = Assert.Throws<ArgumentException>(
                () => Lab1.StringCalculator.CalculateString(s));
        }

        [Theory]
        [InlineData("25,1500\n0", 25)]
        [InlineData("2345,52", 52)]
        [InlineData("687654\n2523523,155235", 0)]
        public void NumbersBiggerThan1000AreIgnored(string s, int expected)
        {
            int res = Lab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("//#\n25#1500\n0", 25)]
        [InlineData("//$\n2345,52$5", 57)]
        [InlineData("//?\n687654\n2523523?155235", 0)]
        public void NewSeparatorCanBeDefined(string s, int expected)
        {
            int res = Lab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("//[#]\n25#1500\n0", 25)]
        [InlineData("//[$::]\n2345$::52$::5", 57)]
        [InlineData("//[??]\n687654\n2523523??155235", 0)]
        public void NewSeparatorCanBeDefinedWithMultipleSymbols(string s, int expected)
        {
            int res = Lab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
    }
}
