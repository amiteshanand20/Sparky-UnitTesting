using Moq;
using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class ProductNUnitTests
    {
        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new Product() { Price = 50};

            var Result = product.GetPrice(new Customer() { IsPlatinum = true });    

            Assert.That(Result, Is.EqualTo(40));    
        }
        [Test]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(x => x.IsPlatinum).Returns(true);

            Product product = new Product() { Price = 50};

            var Result = product.GetPrice(customer.Object);    

            Assert.That(Result, Is.EqualTo(40));    
        }
    }
}
