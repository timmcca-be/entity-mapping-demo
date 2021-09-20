using EntityMappingDemo.Application;
using EntityMappingDemo.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace EntityMappingDemo
{
    class Program
    {
        private static readonly DbConnection _connection = new SqliteConnection("Filename=:memory:");

        private static DbContextOptions<BankingContext> _options =
            new DbContextOptionsBuilder<BankingContext>()
               .UseSqlite(_connection)
               .Options;

        static void Main() => MainAsync().GetAwaiter().GetResult();

        static T Perform<T>(Func<BankingService, T> function)
        {
            using var context = new BankingContext(_options);
            var service = new BankingService(new UnitOfWork(context));
            return function.Invoke(service);
        }

        static async Task MainAsync()
        {
            await _connection.OpenAsync();
            using (var context = new BankingContext(_options))
            {
                await context.Database.EnsureCreatedAsync();
            }
            // each task is performed with a new DB context to simulate requests in an API project
            await Perform(service => service.OpenAccount("Tim"));
            await Perform(service => service.DepositToChecking(1, 100));
            await Perform(service => service.DepositToSavings(1, 50));
            await Perform(service => service.TransferToSavings(1, 75));
            var user = await Perform(service => service.GetUser(1));
            Console.WriteLine("User name (should be Tim): " + user.Name);
            Console.WriteLine("Checking balance (should be 25): " + user.CheckingAccount.Balance);
            Console.WriteLine("Savings balance (should be 125): " + user.SavingsAccount.Balance);
            await _connection.DisposeAsync();
        }
    }
}
