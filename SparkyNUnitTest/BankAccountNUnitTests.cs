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
        private BankAccount bankAccount;
        [SetUp]
        public void SetUp()
        {
            bankAccount = new BankAccount(new LogBook());
        }
        [Test]
        public void Deposit_Add100_ReturnTrue()
        {
            var result = bankAccount.Deposit(100);

            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }
    }
}
