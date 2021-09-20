using EntityMappingDemo.Domain;
using System.Threading.Tasks;

namespace EntityMappingDemo.Domain.Common
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public Task Commit();
    }
}
