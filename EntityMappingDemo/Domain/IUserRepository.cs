using System.Threading.Tasks;

namespace EntityMappingDemo.Domain
{
    public interface IUserRepository
    {
        public Task Add(User user);
        public Task<User> Get(int id);
        public Task<User[]> GetAll();
    }
}
