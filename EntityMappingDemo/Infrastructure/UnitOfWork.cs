using EntityMappingDemo.Domain;
using EntityMappingDemo.Domain.Common;
using EntityMappingDemo.Infrastructure.Users;
using System.Threading.Tasks;

namespace EntityMappingDemo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankingContext _context;
        private IUserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public UnitOfWork(BankingContext context) => _context = context;

        public Task Commit() => _context.SaveChangesAsync();
    }
}
