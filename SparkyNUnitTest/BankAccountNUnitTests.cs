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

        //[Test]
        //public void DepositLogFake_Add100_ReturnTrue()
        //{
        //   BankAccount bankAccount = new BankAccount(new LogFake());

        //    var result = bankAccount.Deposit(100);

        //    Assert.That(result, Is.True);
        //    Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        //}
        
        [Test]
        public void Deposit_Add100_ReturnTrue()
        {
           var logMock = new Mock<ILogBook>();

            BankAccount bankAccount = new BankAccount(logMock.Object);
            var result = bankAccount.Deposit(100);
            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        [TestCase(200,100)]
        public void Withdraw100With200BalanceAmount(int balance,int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDB(It.IsAny<string>())).Returns(true);    
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true); 

            BankAccount account = new BankAccount(logMock.Object);
            account.Deposit(balance);
            var result = account.Withdraw(withdraw);
            Assert.That(result, Is.True);
        }
    }
}
