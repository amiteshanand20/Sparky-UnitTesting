﻿using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class FiboNUnitTests
    {
        [Test]
        public void FiboChecker_Input1_ReturnFiboSeries()
        {
            List<int> expectedRange = new List<int>() { 0 };

            Fibo fibo = new ();
            fibo.Range = 1;

            List<int> result = fibo.GetFiboSeries();

            Assert.That(result,Is.Not.Empty);
            Assert.That(result,Is.Ordered);
            Assert.That(result,Is.EquivalentTo(expectedRange));
        } 
        [Test]
        public void FiboChecker_Input6_ReturnFiboSeries()
        {
            List<int> expectedRange = new List<int>() { 0,1,1,2,3,5 };

            Fibo fibo = new ();
            fibo.Range = 6;

            List<int> result = fibo.GetFiboSeries();

            Assert.That(result,Does.Contain(3));
            Assert.That(result.Count,Is.EqualTo(6));
            Assert.That(result,Has.No.Member(4));
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }
    }
}