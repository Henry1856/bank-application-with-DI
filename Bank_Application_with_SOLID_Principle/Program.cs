using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bank_Application_with_SOLID_Principle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IAccount, Account>();
                    services.AddScoped<ITransaction, Transaction>();
                    services.AddScoped<Menu>();
                })
                .Build();
            using var serviceScope = host.Services.CreateScope();
            var menu = serviceScope.ServiceProvider.GetRequiredService<Menu>();
            menu.BankMenu();
        }
    }
}
