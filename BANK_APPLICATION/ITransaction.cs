using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_APPLICATION
{
    public interface ITransaction
    {
        void DepositFunds(Account account);
        void WithdrawFunds(Account account);

        void TransactionHistory(double accountNumber);
        Transaction CreateTransaction(DateTime transactionDate, string transactionType, decimal balance, decimal amount, string note, double accountNumber);

    }
}
