using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparky;

namespace Sparky
{
    [TestFixture]
    internal class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.AddNumbers(10, 30);

            //Assert
            Assert.That(result, Is.EqualTo(40));

        }

        [Test]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            bool isOdd = calculator.IsOddNumber(24);

            //Assert
            Assert.That(isOdd, Is.EqualTo(false));
            Assert.That(isOdd, Is.False);
        }

        //Single method to test multiple test cases
        [Test]
        [TestCase(11)]
        [TestCase(51)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            bool isOdd = calculator.IsOddNumber(a);

            //Assert
            Assert.That(isOdd, Is.EqualTo(true));
            Assert.That(isOdd, Is.True);


        }

        //Single method to test multiple test with varied expected results
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddNumber_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calculator = new Calculator();

            return calculator.IsOddNumber(a);

        }


        [Test]
        [TestCase(5.4, 10.5)]//15.9
        //[TestCase(5.43 ,10.53)]//15.93
        //[TestCase(5.49,10.59)]//16.08
        public void AddNumbers_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            double result = calculator.AddNumbersDouble(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(15.9));

        }

        [Test]
        public void GetOddRange_InputMinAndMaxRange_ReturnValidOddRange()
        {
            //Arrange
            Calculator calculator = new Calculator();
            List<int> expectedOddRange = new List<int>() { 5,7,9};//5-10

            //Act
            List<int> result = calculator.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.That(result, Does.Contain(7));
            Assert.That(result.Count,Is.EqualTo(3));
            Assert.That(result,Is.Not.Empty);
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);

        }
    }
}
