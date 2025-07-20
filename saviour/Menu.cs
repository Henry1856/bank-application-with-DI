using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_with_SOLID_Principles
{
    public class Menu : IMenu
    {
        private readonly IMethodOfMethods _methodOfMethods;

        public Menu(IMethodOfMethods methodOfMethods)
        {
            _methodOfMethods = methodOfMethods;
        }

        public void Menu1()
        {
            Console.WriteLine("Welcome to financial manager bank, please choose from the below options the services you will like to perform");

            while (true)
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Perform Transactions on existing Account");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    _methodOfMethods.Choice1Method();
                }
                else if (choice == "2")
                {
                    _methodOfMethods.Choice2Method();
                }
                else if (choice == "3")
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
