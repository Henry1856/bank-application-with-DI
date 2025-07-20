using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BANK_APPLICATION
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
                    services.AddScoped< IMenu, Menu>();
                })
                .Build();
                  // Resolve IMenu and run the menu
        using var serviceScope = host.Services.CreateScope();
        var menu = serviceScope.ServiceProvider.GetRequiredService<IMenu>();
        menu.Menu1();
            
        }
    }
}
