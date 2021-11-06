using System;
using CleanerLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanerUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) => {
                    services.AddTransient<IRobotCleaner>(x => new RobotCleaner(TransferToCleaner));
                })
                .Build();
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            var robot = provider.GetRequiredService<IRobotCleaner>();

            Console.WriteLine("Hello World!");
            robot.Work("inputCommands.txt");
            Console.WriteLine("Goodbuy World!");

            host.Run();
        }

        private static void TransferToCleaner(string message)
        {
            Console.WriteLine(message);
        }
    }
}
