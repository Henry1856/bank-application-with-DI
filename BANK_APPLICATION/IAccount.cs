namespace BANK_APPLICATION
{
    public interface IAccount
    {
        void CheckAccountBalance();
        Account CreateAccount();
        double GenerateAccountNumber();
        void GetAccount();
    }
}