using System.Threading.Tasks;

namespace EntityMappingDemo.Domain
{
    public interface IUserRepository
    {
        public Task<IUserID> Add(User user);
        public Task<User> Get(IUserID id);
        public Task<User[]> GetAll();
    }
}
