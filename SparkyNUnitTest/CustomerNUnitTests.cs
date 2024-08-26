﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    internal class CustomerNUnitTests
    {
        [Test]
        public void CombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            Customer customer = new Customer();

            //Act
            customer.CombineNames("Tom", "Hardy");

            //Assert
            Assert.That( customer.GreetMessage, Is.EqualTo("Hello, Tom Hardy"));
            Assert.That(customer.GreetMessage, Does.Contain("Tom"));
            Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
            Assert.That(customer.GreetMessage, Does.EndWith("Hardy"));
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange
            Customer customer = new Customer();

            //Act

            //Assert
            Assert.That(customer.GreetMessage,Is.Null);
        }
    }
}
