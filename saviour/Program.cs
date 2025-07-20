using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Bank_Application_with_SOLID_Principles
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
                    services.AddScoped<IMethodOfMethods, MethodOfMethods>();
                    services.AddScoped<IMenu, Menu>();
                })
                .Build();
            using var serviceScope = host.Services.CreateScope();
            var menu = serviceScope.ServiceProvider.GetRequiredService<IMenu>();
            menu.Menu1();
        }
    }
}
