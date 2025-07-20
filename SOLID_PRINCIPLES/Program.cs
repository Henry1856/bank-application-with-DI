using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SOLID_PRINCIPLES
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddScoped<IAccount, Account>();
                   services.AddScoped<IMethodOfMethods, MethodOfMethods>();
                   services.AddScoped<IMenu, Menu>();
                   services.AddScoped<ITransaction, Transaction>();
               })
               .Build();
            using var serviceScope = host.Services.CreateScope();
            var menu = serviceScope.ServiceProvider.GetRequiredService<IMenu>();
            menu.Menu1();
        }
    }
}
