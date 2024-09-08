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
    public class BankAccountNUnitTests
    {
        private BankAccount account;
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void DepositLogFake_Add100_ReturnTrue()
        {
           BankAccount bankAccount = new BankAccount(new LogFake());

            var result = bankAccount.Deposit(100);

            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }
        
        [Test]
        public void Deposit_Add100_ReturnTrue()
        {
           var logMock = new Mock<LogBook>();

            BankAccount bankAccount = new BankAccount(logMock.Object);
            var result = bankAccount.Deposit(100);
            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }
    }
}
