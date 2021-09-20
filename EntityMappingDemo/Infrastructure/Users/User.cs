namespace EntityMappingDemo.Infrastructure.Users
{
    public class User
    {
        public interface IState
        {
            public string Name { get; set; }
            public uint CheckingBalance { get; set; }
            public bool TransferFromCheckingAllowed { get; set; }
            public bool InStoreWithdrawalFromCheckingAllowed { get; set; }
            public bool CheckWithdrawalFromCheckingAllowed { get; set; }
            public bool ATMWithdrawalFromCheckingAllowed { get; set; }
            public uint SavingsBalance { get; set; }
            public bool TransferFromSavingsAllowed { get; set; }
            public bool InStoreWithdrawalFromSavingsAllowed { get; set; }
            public bool CheckWithdrawalFromSavingsAllowed { get; set; }
            public bool ATMWithdrawalFromSavingsAllowed { get; set; }

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
        public bool TransferFromCheckingAllowed
        {
            get => _state.TransferFromCheckingAllowed;
            set => _state.TransferFromCheckingAllowed = value;
        }
        public bool InStoreWithdrawalFromCheckingAllowed
        {
            get => _state.InStoreWithdrawalFromCheckingAllowed;
            set => _state.InStoreWithdrawalFromCheckingAllowed = value;
        }
        public bool CheckWithdrawalFromCheckingAllowed
        {
            get => _state.CheckWithdrawalFromCheckingAllowed;
            set => _state.CheckWithdrawalFromCheckingAllowed = value;
        }
        public bool ATMWithdrawalFromCheckingAllowed
        {
            get => _state.ATMWithdrawalFromCheckingAllowed;
            set => _state.ATMWithdrawalFromCheckingAllowed = value;
        }
        public uint SavingsBalance
        {
            get => _state.SavingsBalance;
            set => _state.SavingsBalance = value;
        }
        public bool TransferFromSavingsAllowed
        {
            get => _state.TransferFromSavingsAllowed;
            set => _state.TransferFromSavingsAllowed = value;
        }
        public bool InStoreWithdrawalFromSavingsAllowed
        {
            get => _state.InStoreWithdrawalFromSavingsAllowed;
            set => _state.InStoreWithdrawalFromSavingsAllowed = value;
        }
        public bool CheckWithdrawalFromSavingsAllowed
        {
            get => _state.CheckWithdrawalFromSavingsAllowed;
            set => _state.CheckWithdrawalFromSavingsAllowed = value;
        }
        public bool ATMWithdrawalFromSavingsAllowed
        {
            get => _state.ATMWithdrawalFromSavingsAllowed;
            set => _state.ATMWithdrawalFromSavingsAllowed = value;
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
