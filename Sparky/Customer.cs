using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public int OrderTotal { get; set; }
        public int Discount = 15;
        public string GreetMessage { get; set; }
        public bool IsPlatinum { get; set; }
        public Customer()
        {
                IsPlatinum = false;
        }
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

        public CustomerType GetCustomerDetails()
        {
            if(OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            return new PlatinumCustomer();
        }
    }
    public class CustomerType 
    { 
    }
    public class BasicCustomer : CustomerType 
    { 
    }
    public class PlatinumCustomer : CustomerType 
    { 
    }
}
