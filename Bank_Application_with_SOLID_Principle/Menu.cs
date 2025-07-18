using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_with_SOLID_Principle
{
    internal class Menu
    {
        private readonly IAccount _account;
        public Menu(IAccount account)
        {
            _account = account;
        }

        public void BankMenu()
        {
            Console.WriteLine("Welcome to financial manager bank, please choose from the below options the services you will like to perform");

            while (true)
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. to exit");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    _account.CreateAccount();
                }
               
                else if (choice == "2")
                {
                    Console.WriteLine("Thank you for using financial manager bank, have a nice day!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }
        }
    }
}
