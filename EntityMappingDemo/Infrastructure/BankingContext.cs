using EntityMappingDemo.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;

namespace EntityMappingDemo.Infrastructure
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

        public DbSet<User> Users { get; }
    }
}
