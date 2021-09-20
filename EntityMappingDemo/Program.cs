using EntityMappingDemo.Application;
using EntityMappingDemo.Domain;
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
            await Perform(service => service.CreateUser("Tim"));
            await Perform(service => service.OpenCheckingAccount(1));
            await Perform(service => service.OpenSavingsAccount(1));
            await Perform(service => service.Deposit(1, 1, 100));
            await Perform(service => service.Deposit(1, 2, 50));
            await Perform(service => service.Transfer(1, 1, 2, 75));
            try
            {
                await Perform(service => service.Withdraw(1, 2, 15, WithdrawalType.ATM));
                Console.Error.WriteLine("Tried to illegally withdraw from savings, did not get an exception");
                return;
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("Caught expected exception when withdrawing illegally");
            }
            await Perform(service => service.AllowWithdrawalType(1, 2, WithdrawalType.ATM));
            await Perform(service => service.Withdraw(1, 2, 15, WithdrawalType.ATM));
            var user = await Perform(service => service.GetUser(1));
            Console.WriteLine("User name (should be Tim): " + user.Name);
            Console.WriteLine("Checking balance (should be 25): " + user.BankAccount(1).Balance);
            Console.WriteLine("Savings balance (should be 110): " + user.BankAccount(2).Balance);
            Console.WriteLine("Doing more things...");
            await Perform(service => service.DoLotsOfThings(1));
            user = await Perform(service => service.GetUser(1));
            Console.WriteLine("Account 1 balance (should be 15): " + user.BankAccount(1).Balance);
            Console.WriteLine("Account 2 balance (should be 50): " + user.BankAccount(2).Balance);
            Console.WriteLine("Account 3 balance (should be 20): " + user.BankAccount(3).Balance);
            await _connection.DisposeAsync();
        }
    }
}
