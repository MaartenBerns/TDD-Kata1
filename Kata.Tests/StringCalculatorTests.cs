using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add("");

            Assert.That(result, Is.EqualTo(0));
        }

        private static StringCalculator MakeCalc()
        {
            return new StringCalculator();
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Add_SingleNumber_ReturnsThatNumber(string numbers, int expected)
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2", 3)]
        [TestCase("2,3", 5)]
        public void Add_TwoNumbers_SumsThemUp(string numbers, int expected)
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4", 10)]
        [TestCase("1,2,3,4,5", 15)]
        [TestCase("2,3,4,5,6", 20)]
        public void Add_MultipleNumbers_SumsThemUp(string numbers, int expected)
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2\n3", 6)]
        public void Add_MultipleNumbersWithNewLineDelimiter_SumsThemUp(string numbers, int expected)
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n1;2;3", 6)]
        [TestCase("//a\n1a2", 3)]
        [TestCase("//5\n152", 3)]      
        public void Add_MultipleNumbersWithCustomDelimiter_SumsThemUp(string numbers, int expected)
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("-1")]
        [TestCase("-1, -2")]
        [TestCase("-1, -2, -3")]
        public void Add_NegativeNumber_ThrowsException(string numbers)
        {
            StringCalculator sc = MakeCalc();

            Assert.Throws<ArgumentException>(delegate { sc.Add(numbers); });
        }

        [TestCase("1001", 0)]
        [TestCase("1,1001", 1)]
        [TestCase("1,1001,1002", 1)]
        [TestCase("1,2,1001,1002", 3)]
        public void Add_NumbersGreaterThanThousand_IgnoresThemInSum(string numbers, int expected)
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("//[**]\n1**2", 3)]
        [TestCase("//[***]\n1***2", 3)]
        [TestCase("//[*1*]\n1*1*2", 3)]
        public void Add_MultipleNumbersWithCustomDelimiterWithAnyLength_SumsThemUp(string numbers, int expected)
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[*][%][^]\n1*2%3^4", 10)]
        [TestCase("//[*][%][^][-]\n1*2%3^4-5", 15)]        
        public void Add_MultipleNumbersWithMultipleCustomDelimiters_SumsThemUp(string numbers, int expected)
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);        
        }

        [TestCase("//[**][%]\n1**2%3", 6)]
        [TestCase("//[***][%%][^]\n1***2%%3^4", 10)]
        public void Add_MultipleNumbersWithMultipleCustomDelimitersWithAnyLength_SumsThemUp(string numbers, int expected)
        {
            StringCalculator sc = MakeCalc();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }
    }
}
