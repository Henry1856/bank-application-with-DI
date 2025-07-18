using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_with_SOLID_Principle
{
    internal class Transaction :ITransaction
    {
        public DateTime transactionDate;
        public decimal balance;
        public decimal amount;
        public string transactionTpye1;
        public string note;
        public double accountNumber;
        public static List<Transaction> bankTransactionHistory = new List<Transaction>();
        public Transaction CreateTransaction(DateTime transactionDate, string transactionType, decimal balance, decimal amount, string note, double accountNumber)
        {
            var newTransaction = new Transaction
            {
                transactionDate = transactionDate,
                transactionTpye1 = transactionType,
                balance = balance,
                amount = amount,
                note = note,
                accountNumber = accountNumber
            };
            return newTransaction;
        }
        public void DepositFunds(Account account)
        {
            decimal amount;
            while (true)
            {
                Console.WriteLine("Enter Amount To Deposit");
                string input = Console.ReadLine();
                if (!decimal.TryParse(input, out amount))
                {
                    Console.WriteLine("Please enter digits only.");
                    continue;
                }
                break;
            }
            Console.WriteLine("enter note");
            string note = Console.ReadLine();
            if (amount > 0)
            {
                account.balance = account.balance + amount;
                Console.WriteLine($" The sum of {amount} naira was deposited successfully. your new balance is {account.balance}");
            }
            else
            {
                Console.WriteLine($"{new ArgumentException("please enter a positive value")}");
            }
            bankTransactionHistory.Add(CreateTransaction(DateTime.Now, "deposit", account.balance, amount, note, account.accountNumber));
        }
        public void WithdrawFunds(Account account)
        {
            decimal amount;
            while (true)
            {
                Console.WriteLine("Enter Amount To Withdraw");
                string input = Console.ReadLine();
                if (!decimal.TryParse(input, out amount))
                {
                    Console.WriteLine("Please enter digits only.");
                    continue;
                }
                break;
            }
            string note = Console.ReadLine();
            if (account.balance < amount)
            {
                Console.WriteLine($"withdrawal amount  cannot exceed current balance ");
            }
            else if (amount > 0)
            {
                account.balance = account.balance - amount;
                bankTransactionHistory.Add(CreateTransaction(DateTime.Now, "withdrawal", account.balance, amount, note, account.accountNumber));
                Console.WriteLine($" {amount} was successfully withdrawn and your new balance is {account.balance} ");
            }
            else
            {
                Console.WriteLine($"{new ArgumentException("please enter a positive value only")}");
            }
            Console.WriteLine("enter note");
        }
        public void TransactionHistory(double accountNumber)
        {
            bool found = false;
            foreach (var history in bankTransactionHistory)
            {
                if (history.accountNumber == accountNumber)
                {
                    Console.WriteLine($"Transaction date: {history.transactionDate}, Transaction Type: {history.transactionTpye1}, Balance: {history.balance}, Amount: {history.amount}, Note: {history.note}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No transaction history found for this account number.");
            }
        }
    }
}
