using EntityMappingDemo.Domain;

namespace EntityMappingDemo.Infrastructure.Users
{
    public class UserID : IUserID
    {
        // Store the whole user here, as its ID will be updated once the changes are committed
        private readonly User _user;

        public UserID(User user) => _user = user;

        public int Value => _user.ID;
    }
}
