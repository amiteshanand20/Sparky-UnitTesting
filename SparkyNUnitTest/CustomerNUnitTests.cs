using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    internal class CustomerNUnitTests
    {
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer(); //global initialization for class
        }
        [Test]
        public void CombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            //Customer customer = new Customer();

            //Act
            customer.CombineNames("Tom", "Hardy");

            //Assert 
            //Multiple method will run other test cases even if one of them fails
            Assert.Multiple(() =>
            {
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Tom Hardy"));
                Assert.That(customer.GreetMessage, Does.Contain("Tom"));
                Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(customer.GreetMessage, Does.EndWith("Hardy"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
           
            
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange
            //Customer customer = new Customer();

            //Act

            //Assert
            Assert.That(customer.GreetMessage,Is.Null);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            //Arrange

            int result = customer.Discount;

            //Assert
            Assert.That(result,Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_EmptyLastName_ReturnsNotNull()
        {
            customer.CombineNames("Tom", "");
            Assert.That(customer.GreetMessage,Is.Not.Null);
        }

        [Test]
        public void GreetMessage_EmptyFistName_ThrowException()
        {
            var ExceptionDetails = Assert.Throws<ArgumentException>(() => customer.CombineNames("", "hanks"));
            Assert.That(ExceptionDetails.Message, Is.EqualTo("First name is empty"));
            Assert.That(() => customer.CombineNames("", "hanks"), Throws.ArgumentException.With.Message.EqualTo("First name is empty"));

            //check exception is thrown
            Assert.Throws<ArgumentException>(() => customer.CombineNames("", "hanks"));
            Assert.That(() => customer.CombineNames("", "hanks"), Throws.ArgumentException);

        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Orders_ReturnsBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        } 
        
        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Orders_ReturnsPlatinumCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
