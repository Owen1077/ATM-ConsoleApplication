using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Task
{
    public class Options
    {
      
        static string date;
        static string description;
        static double amount;
        static double balance;
        static string cardNumber;


        public static void addingList()
        {

            string transactionPath = @"C:\Users\Decagon\source\repos\Empire\Owen\Stage two\ATM Task\E_Transactions.json";


            var E_transactions = File.ReadAllText(transactionPath);

            List<NewCustomerList> transaction = JsonConvert.DeserializeObject<List<NewCustomerList>>(E_transactions);

            NewCustomerList newCustomerList = new NewCustomerList(date, description, amount, balance, cardNumber);


            transaction.Add(newCustomerList);

            var json = JsonConvert.SerializeObject(transaction);
            var fileInfo = new FileInfo(transactionPath);
            using (var users = new StreamWriter(fileInfo.Open(FileMode.Truncate)))
            {
                users.WriteLine(json);
            }


        }

     
        public static void menuOptions()
        {
            Console.WriteLine("Welcome! Please choose one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Show balance");
            Console.WriteLine("5. Show statement of account");
            Console.WriteLine("6. Log out");
        }
        public static void depositing(Customer currentUser)
        {


            Console.WriteLine("How much do you want to deposit? ");
            amount = Double.Parse(Console.ReadLine());
            currentUser.balance += amount;
            Console.WriteLine($"Thank you for your money. Your new balance is {currentUser.balance}");
            description = "Deposit";
            balance = currentUser.balance;
            date = DateTime.Now.ToString("dd/MM/yyyy");
            cardNumber = currentUser.cardNumber;

            addingList();


        }
        public static void withdrawal(Customer customer)
        {



            Console.WriteLine("How much do you want to withdraw? ");
            amount = Double.Parse(Console.ReadLine());
            if (amount > customer.balance)
            {
                Console.WriteLine("Insufficient funds");
                menuOptions();
            } else if (customer.accountType == "Savings" && (customer.balance - amount) < 1000)
                {
                    Console.WriteLine("Your account is too low for this transaction");
                withdrawal(customer);
                }
            else
            {
                customer.balance = customer.balance - amount;
                Console.WriteLine($"Your new balance is {customer.balance}");
                description = "Withdrawal";
                balance = customer.balance;
                date = DateTime.Now.ToString("dd/MM/yyyy");
                cardNumber= customer.cardNumber;

                addingList();


            }

        }
        public static void transferring(Customer customer, List<Customer> results)
        {


            Customer customer1;
        ro:
            Console.WriteLine("Enter the account number you would like to transfer to:");
            try {
                string number = Console.ReadLine();

                if(number == customer.cardNumber)
                {
                    Console.WriteLine("Enter an account number that isn't yours");
                    goto ro;
                }

                //TAKE NOTE OF THIS LINE BELOW
                customer1 = results.FirstOrDefault(a => a.cardNumber == number);


                if (customer1 != null)
                {
                    Console.WriteLine($"Let's proceed {customer.firstName}");


                    Console.WriteLine($"Enter the amount you want to transfer to {customer1.firstName}:");
                     amount = Double.Parse(Console.ReadLine());

                    if (customer.balance > amount && !((customer.balance - amount) < 1000))
                    {
                        customer.balance -= amount;
                        customer1.balance += amount;


                        Console.WriteLine("Done");
                        description = "Transfer";
                        balance = customer.balance;
                        date = DateTime.Now.ToString("dd/MM/yyyy");
                        cardNumber = customer.cardNumber;

                        addingList();



                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds");
                    }
                }
                else
                {
                    Console.WriteLine("Account number not detected");
                    //menuOptions();
                }

            }
            catch { Console.WriteLine("Not found"); }


        }
        public static void checkBalance(Customer currentUser)
        {
            Console.WriteLine($"Your current balance is {currentUser.balance}");
        }

       
    }
}
