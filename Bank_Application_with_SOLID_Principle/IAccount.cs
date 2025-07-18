using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_with_SOLID_Principle
{
    internal interface IAccount
    {
        void CheckAccountBalance();
        void CreateAccount();
        double GenerateAccountNumber();
        void GetAccount();
    }
}
