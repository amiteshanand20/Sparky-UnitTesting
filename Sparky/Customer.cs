using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ICustomer
    {
        int OrderTotal { get; set; }
        int Discount { get; set; }
        string GreetMessage { get; set; }
        bool IsPlatinum { get; set; }
        string CombineNames(string firstName, string lastName);
        CustomerType GetCustomerDetails();

     }
    
    public class Customer :ICustomer
    {
        public int OrderTotal { get; set; }
        public int Discount { get; set; }
        public string GreetMessage { get; set; }
        public bool IsPlatinum { get; set; }
        public Customer()
        {
                Discount = 15;
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

