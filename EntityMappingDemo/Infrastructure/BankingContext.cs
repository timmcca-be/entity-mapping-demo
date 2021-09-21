using EntityMappingDemo.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace EntityMappingDemo.Infrastructure
{
    public class BankingContext : DbContext
    {
        private static readonly LoggerFactory _loggerFactory =
            new LoggerFactory(new[] { new DebugLoggerProvider() });

        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseLoggerFactory(_loggerFactory);

        public DbSet<User> Users { get; set; }
    }
}
