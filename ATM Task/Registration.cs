using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace ATM_Task
{
    public class Registration 
    {
        
        public void registration()
        {
            string firstName;
            string lastName;
            string cardNumber = generate();
            string pin;
            double balance = 0;
            string email;
            bool savings = false;
            bool current = false;
            string accountType = "";


        point:
            Console.WriteLine("Please select the type of account you wish to create \n");
            Console.WriteLine("1. Current Account");
            Console.WriteLine("2. Savings Account");
            Console.WriteLine("3. Back");

            string selectOption = Console.ReadLine();
            if (selectOption == "1")
            {
                current = true;
                accountType = "Current";
              
            }
            else if (selectOption == "2")
            {
                savings = true;
                accountType = "Savings";
            }
            else if (selectOption == "3")
            {
                Menu.MainMenu();
                
            }
            else
            {
                Console.WriteLine("Invalid input");
                goto point;
            }


            if (selectOption != "3")
            {
                yo:
                Console.WriteLine("Please enter your first name:\n");
                firstName = Console.ReadLine();

                if(!(firstName.Length > 1) || !(char.IsUpper(firstName[0])))
                {
                    Console.WriteLine("Enter your name starting with an uppercase e.g John");
                    goto yo;
                }

               zo:
                Console.WriteLine("Please enter your last name:");
                lastName = Console.ReadLine();

                if (!(lastName.Length > 1 && char.IsUpper(lastName[0])))
                {
                    Console.WriteLine("Enter your name starting with an uppercase e.g John");
                    goto zo;
                }
                
                Console.WriteLine("Please enter your six digit pin known only to you:");
            xo:
                pin = Console.ReadLine();
                var valid = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[@#$%^&!]).{6,}$");
             
                if ( !valid.IsMatch(pin))
                {
                    Console.WriteLine("Enter a valid pin that includes an upper and lower case, a number and any of these characters: @, #, $, %, ^, &, !");
                    goto xo;
                }
                wo:
                Console.WriteLine("Please enter a valid email address in the format 'abc@mail.com'");
                email = Console.ReadLine();
                var valids = new Regex(@"^(?=.*?[a-z])(?=.*?[0-9])(?=.*?[@.]).{7,}$");
                if (!valids.IsMatch(email)) {
                    goto wo;
                }


                Console.WriteLine(firstName + " " + lastName);
                if (current)
                {
                    Console.WriteLine("Current account");
                }
                if (savings)
                {
                    Console.WriteLine("Savings account");
                }


                Console.WriteLine($"your account number is {cardNumber}\n\n");
                
                Customer customer = new Customer(firstName, lastName, cardNumber, pin, balance, email, accountType);



                    string path = @"C:\Users\Decagon\source\repos\Empire\Owen\Stage two\ATM Task\E_Customers.json";


                var E_customers = File.ReadAllText(path);

                List<Customer> result = JsonConvert.DeserializeObject<List<Customer>>(E_customers);

                var E_customer = new Customer(firstName, lastName, cardNumber, pin, balance, email, accountType);

                result.Add(E_customer);

                var json = JsonConvert.SerializeObject(result);
                    var fileInfo = new FileInfo(path);
                    using (var users = new StreamWriter(fileInfo.Open(FileMode.Truncate)))
                    {
                        users.WriteLine(json);
                    }



            Menu.MainMenu();
               
            }
        }
           public static string generate()
        {
            Random random = new Random();
            string cardNumber = "0" + random.Next(100000000, 999999999);
            return cardNumber.ToString();
        }

    }
}
