namespace EntityMappingDemo.Infrastructure.Users
{
    public class User
    {
        public interface IState
        {
            public string Name { get; set; }
            public uint CheckingBalance { get; set; }
            public uint SavingsBalance { get; set; }

            public IState CreateDomainObject();
            public Domain.User DomainObject { get; }
        }

        public int ID { get; set; }
        public string Name
        {
            get => _state.Name;
            set => _state.Name = value;
        }
        public uint CheckingBalance
        {
            get => _state.CheckingBalance;
            set => _state.CheckingBalance = value;
        }
        public uint SavingsBalance
        {
            get => _state.SavingsBalance;
            set => _state.SavingsBalance = value;
        }

        private IState _state;

        public User() => _state = new Initializing();
        public User(Domain.User domainObject) => _state = new Sealed(domainObject);

        public Domain.User DomainObject
        {
            get
            {
                _state = _state.CreateDomainObject();
                return _state.DomainObject;
            }
        }
    }
}
