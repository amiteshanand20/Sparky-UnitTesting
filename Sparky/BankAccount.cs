﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        public int balance { get; set; }
        private readonly ILogBook _logBook;

        public BankAccount(ILogBook logBook)
        {
            _logBook = logBook;
                balance = 0;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit Invoked");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
           var temp =  _logBook.LogSeverity;
            balance += amount;
            return true;
        } 
        public bool Withdraw(int amount)
        {
            if (balance >= amount) 
            {
                _logBook.LogToDB("Withdrawal amount =" + amount.ToString());
                balance -= amount;
                return _logBook.LogBalanceAfterWithdrawal(balance);
            }
            return _logBook.LogBalanceAfterWithdrawal(balance - amount);
        }
        public int GetBalance() 
        { 
            return balance;
        }
    }
}
