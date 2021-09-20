using EntityMappingDemo.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EntityMappingDemo.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly BankingContext _context;

        public UserRepository(BankingContext context)
        {
            _context = context;
        }

        public async Task Add(Domain.User domainObject)
        {
            await _context.AddAsync(new User(domainObject));
        }

        public async Task<Domain.User> Get(int id)
        {
            var entity = await _context.FindAsync<User>(id);
            return entity.DomainObject;
        }

        public async Task<Domain.User[]> GetAll()
        {
            var entities = await _context.Users.ToListAsync();
            return entities.Select(user => user.DomainObject).ToArray();
        }
    }
}
