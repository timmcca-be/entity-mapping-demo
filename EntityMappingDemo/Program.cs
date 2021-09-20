using EntityMappingDemo.Application;
using EntityMappingDemo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EntityMappingDemo
{
    class Program
    {
        static void Main() => MainAsync().GetAwaiter().GetResult();

        private static DbContextOptions<BankingContext> _options =
            new DbContextOptionsBuilder<BankingContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

        static T Perform<T>(Func<BankingService, T> function)
        {
            using var context = new BankingContext(_options);
            var service = new BankingService(new UnitOfWork(context));
            return function.Invoke(service);
        }

        static async Task MainAsync()
        {
            // each task is performed with a new DB context to simulate requests in an API project
            await Perform(service => service.OpenAccount("Tim"));
            await Perform(service => service.DepositToChecking(1, 100));
            await Perform(service => service.DepositToSavings(1, 50));
            await Perform(service => service.TransferToSavings(1, 75));
            var user = await Perform(service => service.GetUser(1));
            Console.WriteLine("User name (should be Tim): " + user.Name);
            Console.WriteLine("Checking balance (should be 25): " + user.CheckingAccount.Balance);
            Console.WriteLine("Savings balance (should be 125): " + user.SavingsAccount.Balance);
        }
    }
}
