using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Task
{
    public class Customer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cardNumber { get; set; }
        public string pin { get; set; }
        public double balance { get; set; }
        public string email { get; set; }
        public string accountType { get; set; }

        public Customer(string firstName, string lastName, string cardNumber, string pin, double balance, string email, string accountType)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.balance = balance;
            this.email = email;
            this.accountType = accountType;
        }
    }
}
