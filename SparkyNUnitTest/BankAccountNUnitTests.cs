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
        public void BankWithdraw_Withdraw100With200BalanceAmount_ReturnsTrue(int balance,int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDB(It.IsAny<string>())).Returns(true);    
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true); 

            BankAccount account = new BankAccount(logMock.Object);
            account.Deposit(balance);
            var result = account.Withdraw(withdraw);
            Assert.That(result, Is.True);
        }
        
        [Test]
        [TestCase(100,200)]
        public void BankWithdraw_Withdraw200With100BalanceAmount_ReturnsFalse(int balance,int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDB(It.IsAny<string>())).Returns(true);    
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true); 
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false); 

            BankAccount account = new BankAccount(logMock.Object);
            account.Deposit(balance);
            var result = account.Withdraw(withdraw);
            Assert.That(result, Is.False);
        } 
        
        [Test]
        public void BankLogDummy_InputStringReturnsFalse()
        {
            var logMock = new Mock<ILogBook>();
            var desiredOutput = "hello";
            logMock.Setup(x => x.MessageWithReturnStringStr(It.IsAny<string>())).Returns((string str) => str.ToLower()); 

            Assert.That(logMock.Object.MessageWithReturnStringStr("Hello"), Is.EqualTo(desiredOutput));
        }  
        [Test]
        public void BankLogDummy_LogwithOutputString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello" ;
            logMock.Setup(x => x.MessageWithOutputStringStr(It.IsAny<string>(),out desiredOutput)).Returns(true);
            string result = "";
            Assert.That(logMock.Object.MessageWithOutputStringStr("Ben", out result));
            Assert.That(result,Is.EqualTo(desiredOutput));
        }
    }
}
