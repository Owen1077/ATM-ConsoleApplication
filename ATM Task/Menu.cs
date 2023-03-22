using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Task
{
    public class Menu
    {
        public static List<Customer> customers = new List<Customer>();
        public static List<NewCustomerList> secondList = new List<NewCustomerList>();

        public static void MainMenu()
        {
            Registration registration = new Registration();
            Login login = new Login();

            Console.WriteLine("Greetings... Hope you're having a great day");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");

            string option = Console.ReadLine();
            if (option != "1" && option != "2" && option != "3")
            {
                Console.WriteLine("Please enter 1, 2, or 3");
                MainMenu();
            }
            switch (option)
                {
                    case "1":
                        registration.registration();
                    break;

                    case "2":
                        Login.login();
                        break;

                    case "3":
                        Console.WriteLine("Goodbye");
                        break;

                    default:
                        break;
            }

        }
    }
}
