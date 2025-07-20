using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace SOLID_PRINCIPLES
{
    public class Account : IAccount
    {
        public string accountHolderName;
        public decimal balance;
        public double accountNumber;
        public DateOnly DateOfBirth;
        public string bvn;
        public string email;
        public string accountType;
        public List<Transaction> bankTransactionHistory = new List<Transaction>();

        public static List<Account> accounts = new List<Account>();
        private readonly ITransaction _transaction;
        public Account(ITransaction transaction)
        {
            _transaction = transaction;
        }


        public void CreateAccount()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        AccountTpye myType = new AccountTpye();
                        Console.WriteLine(" enter savings or  current");
                        accountType = Console.ReadLine().ToLower();
                        if (accountType == "savings")
                        {
                            myType = AccountTpye.savings;
                        }
                        else if (accountType == "current")
                        {
                            myType = AccountTpye.current;
                        }
                        else
                        {
                            throw new Exception("Invalid account type. Please enter 'savings' or 'current'.");
                        }
                        Console.WriteLine($"You have selected {myType} account type.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Pleas enter either 'savings' or 'current' ");
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Please provide the following details to create your account:");

                Console.WriteLine("Enter E.Mail Address");
                while (true)
                {
                    email = Console.ReadLine();
                    string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                    if (!Regex.IsMatch(email, emailPattern))
                    {
                        Console.WriteLine("Please enter a valid email address.");
                        continue;
                    }
                    bool emailExists = accounts.Exists(a => a.email == email );
                    if (emailExists)
                    {
                        Console.WriteLine($"{email} : Email already exists , Please enter a different email address.");
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Enter BVN");
                while (true)
                {
                    bvn = Console.ReadLine();
                    if (!Regex.IsMatch(bvn, @"^\d{11}$"))
                    {
                        Console.WriteLine("Invalid BVN. Please enter an 11-digit BVN.");
                        continue;
                    }
                    bool bvnExists = accounts.Exists(a => a.bvn == bvn );
                    if (bvnExists)
                    {
                        Console.WriteLine($"{bvn} : BVN already exists, Please enter a different BVN.");
                        continue;
                    }
                    break;
                }
                Console.WriteLine("enter your fullName");
                while (true)
                {
                    accountHolderName = Console.ReadLine().ToUpper();
                    if (Regex.IsMatch(accountHolderName, @"^[A-Z\s]+$"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid name. Please enter a valid name.");
                    }
                }
                Console.WriteLine("enter date of birth YYYY-MM-DD");
                while (true)
                {
                    string date = Console.ReadLine();
                    if (DateOnly.TryParse(date, out DateOfBirth))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date in the format YYYY-MM-DD.");
                    }
                }
                Console.WriteLine("enter initial deposit amount");

                while (true)
                {
                    string amount = Console.ReadLine();
                    if (decimal.TryParse(amount, out balance) && balance > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a positive numeric value for the initial deposit.");
                    }
                    
                }
                accountNumber = GenerateAccountNumber();
                var transaction = _transaction.CreateTransaction(DateTime.Now, "deposit", balance, balance, "", accountNumber);
                bankTransactionHistory.Add(transaction);

                Console.WriteLine($@"{accountHolderName} was successfully created with account number {accountNumber} and initial deposit of {balance}");
                Console.WriteLine($"accountHolderName : {accountHolderName}, accountBalance : {balance}");
                Console.WriteLine($"USER DETAILS :  accountHolderName {accountHolderName}, accountNumber : {accountNumber}, DateOfBirth : {DateOfBirth}, bvn : {bvn}, email : {email}, accountType : {accountType}");
                accounts.Add(this);
                //accounts.Add(new Account(_transaction)
                //{
                //    accountHolderName = accountHolderName,
                //    balance = balance,
                //    accountNumber = accountNumber,
                //    DateOfBirth = DateOfBirth,
                //    bvn = bvn,
                //    email = email,
                //    accountType = accountType
                //});
            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }
        }
             public void CheckAccountBalance()
        {
            Console.WriteLine($"Your current balance is {balance}");
        }
        public void GetAccount()
        {
            Console.WriteLine("enter bvn number");
            bvn = Console.ReadLine();
            foreach (var account in accounts)
            {
                if (account.bvn == bvn)
                {
                    Console.WriteLine($"Account Holder: {account.accountHolderName}, Account Number: {account.accountNumber}, Balance: {account.balance}, Account Type: {account.accountType}");
                }
                else
                {
                    Console.WriteLine($"No account found with bvn: {bvn}");
                }
            }
        }
        enum AccountTpye
        {
            savings,
            current,
        }
        public double GenerateAccountNumber()
        {
            int length = 10;
            Random random = new Random();
            int[] digits = new int[length];
            for (int i = 0; i < length; i++)
            {
                digits[i] = random.Next(0, 10);
            }
            string accountNumber = string.Join("", digits);
            Console.WriteLine($"Your account number is {accountNumber}");
            return double.Parse(accountNumber);
        }

    }
}
