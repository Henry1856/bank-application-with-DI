using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_PRINCIPLES
{
    public interface IAccount
    {
        void CheckAccountBalance();
        void CreateAccount();

        double GenerateAccountNumber();
        void GetAccount();
    }
}
