//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using Bank_Application_with_SOLID_Principles;

//namespace Bank_Application_With_SOLID_Principles_2
//{
//    internal class TESTING
//    {
//        public static void Main(string[] args)
//        {
//            // This is a placeholder for the main method.
//            // You can instantiate your classes and call methods here to test functionality.
//            Console.WriteLine("Welcome to the Bank Application!");
//            // Example: Create an account, perform transactions, etc.


//            foreach (var account in accounts)
//            {
//                if (account.bvn == bvn && account.accountType == accountType && account.email == email)
//                {
//                    Console.WriteLine($" Account Type: {account.accountType} with  BVN: {account.bvn} and {account.email} , already exist");
//                    exit1 = true;

//                }
//                else if (account.accountType == accountType && account.email == email)
//                {
//                    Console.WriteLine($" Account Type: {account.accountType} and email {account.email}, already exist");
//                    exit2 = true;

//                }

//            }


//            //if (exit1 || exit2)
//            //{
//            //    Console.WriteLine("Account creation failed due to duplicate account.");
//            //    return null;
//            //}

//            Console.WriteLine("enter your fullName");
//            while (true)
//            {
//                accountHolderName = Console.ReadLine().ToUpper();
//                if (Regex.IsMatch(accountHolderName, @"^[A-Z\s]+$"))
//                {
//                    break;
//                }
//                else
//                {
//                    Console.WriteLine("Invalid name. Please enter a valid name.");
//                }
//            }
//            Console.WriteLine("enter date of birth YYYY-MM-DD");
//            while (true)
//            {
//                string date = Console.ReadLine();
//                if (DateOnly.TryParse(date, out DateOfBirth))
//                {
//                    break;
//                }
//                else
//                {
//                    Console.WriteLine("Invalid date format. Please enter a valid date in the format YYYY-MM-DD.");
//                }
//            }
//            Console.WriteLine("enter initial deposit amount");

//            while (true)
//            {
//                string amount = Console.ReadLine();
//                if (decimal.TryParse(amount, out balance) && balance > 0)
//                {
//                    break;
//                }
//                else
//                {
//                    Console.WriteLine("Invalid amount. Please enter a positive numeric value for the initial deposit.");
//                }
//            }
//            accountNumber = GenerateAccountNumber();
//            var transaction = _transaction.CreateTransaction(DateTime.Now, "deposit", balance, balance, "", accountNumber);
//            Transaction.bankTransactionHistory.Add(transaction);
//            accounts.Add(this);
//            Console.WriteLine($@"{accountHolderName} was successfully created with account number {accountNumber} and initial deposit of {balance}");
//            Console.WriteLine($"accountHolderName : {accountHolderName}, accountBalance : {balance}");
//            var newAccount = new Account(_transaction) { accountHolderName = accountHolderName, balance = balance, accountNumber = accountNumber, DateOfBirth = DateOfBirth, bvn = bvn, email = email, accountType = accountType };
//            return newAccount;
//        }
//    }
//}
