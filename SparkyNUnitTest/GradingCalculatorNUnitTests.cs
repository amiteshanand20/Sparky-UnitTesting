using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    internal class GradingCalculatorNUnitTests
    {
        private GradingCalculator gradingCalculator;

        [SetUp]
        public void Setup()
        {
            gradingCalculator = new GradingCalculator(); //global initialization for class
        }
        [Test]
        public void GetGrade_InputScore95Attendance90_ReturnAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void GetGrade_InputScore85tendance90_ReturnBrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void GetGrade_InputScor70Attendance65eturnCGrade()
        {
            gradingCalculator.Score = 70;
            gradingCalculator.AttendancePercentage = 65;
            string result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void GetGrade_InputScore95Attendance65_ReturnBGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            string result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }
        [Test]
        [TestCase(95,55)]
        [TestCase(65,55)]
        [TestCase(50,90)]
        public void GetGrade_InputScore25Attendance35_ReturnFGrade(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            string result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("F"));
        }

    }
}
