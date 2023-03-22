using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Task
{
    public class NewCustomerList
    {
        public string date { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public double balance { get; set; }
        public string cardNumber { get; set; }

        public NewCustomerList (string date, string description, double amount, double balance, string cardNumber)
        {
            this.date = date;
            this.description = description;
            this.amount = amount;
            this.balance = balance;
            this.cardNumber = cardNumber;
        }
    }
}
