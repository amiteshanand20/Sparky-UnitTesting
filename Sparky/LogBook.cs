﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        void Message(string message);   
    }
    public  class LogBook :ILogBook
    {
        public void Message(string message)
        {
            System.Console.WriteLine(message);
        }
    } 
    public  class LogFake :ILogBook
    {
        public void Message(string message)
        {
        }
    }
}