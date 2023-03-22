using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Task
{
    public class StatementOfAccount
    {
        public static void AccountDetails(Customer customer, List<Customer> result)
        {

            string transactionPath = @"C:\Users\Decagon\source\repos\Empire\Owen\Stage two\ATM Task\E_Transactions.json";


            var E_transactions = File.ReadAllText(transactionPath);

            List<NewCustomerList> transaction = JsonConvert.DeserializeObject<List<NewCustomerList>>(E_transactions);

        

            Console.WriteLine("ACCOUNT DETAILS");

        Console.WriteLine("\n|---------------------|--------------|-------------|----------------|\n" +
                            "|FULL NAME            |ACCOUNT NUMBER|ACCOUNT TYPE |ACCOUNT BALANCE |\n" +
                            "|---------------------|--------------|-------------|----------------|");

                    Console.WriteLine($"|{(customer.firstName).ToUpper() + " " + (customer.lastName).ToUpper(), -20} |{customer.cardNumber, -10}    |{customer.accountType, -10}   |{customer.balance, -10}      |");

          Console.WriteLine("|---------------------|--------------|-------------|----------------|\n");



            Console.WriteLine($"\nACCOUNT STATEMENT ON ACCOUNT NO {customer.cardNumber}");

            Console.WriteLine("\n|----------------|------------------|-------------------|-------------------|\n" +
                                "|DATE            |DESCRIPTION       |AMOUNT             |BALANCE            |\n" +
                                "|----------------|------------------|-------------------|-------------------|");


            
            foreach (var n in transaction)
            {
                if ((n.cardNumber).Equals(customer.cardNumber))
                {
                    Console.WriteLine($"|{n.date, -15} |{n.description, -15}   |{n.amount,-15}    |{n.balance,-15}    |");
                }
            }
            Console.WriteLine("|----------------|------------------|-------------------|-------------------|");





            var resultJson = JsonConvert.SerializeObject(transaction);

            File.WriteAllText(transactionPath, resultJson);
        }

    }
}
