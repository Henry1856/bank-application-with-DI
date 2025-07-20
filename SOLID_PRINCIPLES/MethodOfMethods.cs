using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SOLID_PRINCIPLES
{
    public class MethodOfMethods :IMethodOfMethods
    {
        public List<Transaction> bankTransactionHistory = new List<Transaction>();

        public static List<Account> accounts = new List<Account>();
        private readonly ITransaction _transaction;
        private readonly IAccount _account;
        public MethodOfMethods(ITransaction transaction, IAccount account)
        {
            _transaction = transaction;
            _account = account;
        }

        public  void Choice2Method()
        {
            Console.WriteLine("Enter your account number");

            double accountNumber = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, @"^\d{10}$"))
                {
                    accountNumber = double.Parse(input);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Account Number. Please enter a valid 10-digit account number.");
                }
            }
            var SelectedAccount = accounts.FirstOrDefault(a => a.accountNumber == accountNumber);
            if (SelectedAccount != null)
            {
                Console.WriteLine($"Welcome {SelectedAccount.accountHolderName}, what would you like to do?");
                while (true)
                {
                    Console.WriteLine("enter '1' to Deposit Funds, '2' to Withdraw Funds, '3' to View Transaction History, '4' to View Current Balance, '5' to GetAccount, '6' return to main manu");
                    string operation = Console.ReadLine();
                    if (operation == "1")
                    {
                        _transaction.DepositFunds(SelectedAccount);
                    }
                    else if (operation == "2")
                    {
                        _transaction.WithdrawFunds(SelectedAccount);
                    }
                    else if (operation == "3")
                    {
                        _transaction.TransactionHistory(SelectedAccount.accountNumber);
                    }
                    else if (operation == "4")
                    {
                        SelectedAccount.CheckAccountBalance();
                    }
                    else if (operation == "5")
                    {
                        SelectedAccount.GetAccount();
                    }
                    else if (operation == "6")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid operation, please try again.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Account not found, please try again.");

            }
        }
        public  void Choice1Method()
        {
            _account.CreateAccount();
            //Account account = new Account();
            //account.CreateAccount();
            //accounts.Add(account);
        }
    }
}
