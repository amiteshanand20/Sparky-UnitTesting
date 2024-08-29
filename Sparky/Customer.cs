using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public int Discount = 15;
        public string GreetMessage { get; set; }
        public string CombineNames(string firstName, string lastName)
        {
            if(string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name is empty");
            }
            GreetMessage=  $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage ;
        }
    }
}
