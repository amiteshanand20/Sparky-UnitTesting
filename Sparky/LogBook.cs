using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        void Message(string message);   
        bool LogToDB(string message);   
        bool LogBalanceAfterWithdrawal(int  balanceAfterWithdrawal);
        string MessageWithReturnStringStr(string message);
        bool MessageWithOutputStringStr(string message,out string str);
        bool LogWithRefObj(ref Customer customer);
    }
    public  class LogBook :ILogBook
    {
        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if (balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failure");
            return false;
        }

        public bool LogToDB(string message)
        {
            Console.WriteLine(message);
            return true;    
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }

        public void Message(string message)
        {
            System.Console.WriteLine(message);
        }

        public bool MessageWithOutputStringStr(string message, out string str)
        {
            str = "Hello" + message;
            return true;
        }

        public string MessageWithReturnStringStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    } 
    //public  class LogFake :ILogBook
    //{
    //    public void Message(string message)
    //    {
    //    }
    //}
}
