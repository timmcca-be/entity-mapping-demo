using EntityMappingDemo.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;

namespace EntityMappingDemo.Infrastructure
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property);
        }

        public DbSet<User> Users { get; }
    }
}
