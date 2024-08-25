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
        [Test]
        public void CombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            Customer customer = new Customer();

            //Act
            string fullName = customer.CombineNames("Tom", "Hardy");

            //Assert
            Assert.That( fullName, Is.EqualTo("Tom Hardy"));
        }
    }
}
