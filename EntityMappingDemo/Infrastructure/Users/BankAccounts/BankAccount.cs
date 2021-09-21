using EntityMappingDemo.Infrastructure.Users.BankAccounts.States;

namespace EntityMappingDemo.Infrastructure.Users.BankAccounts
{
    public class BankAccount : IPersistable<Domain.BankAccount>
    {
        public interface IState
        {
            public uint Balance { get; set; }
            public bool TransferWithdrawalsAllowed { get; set; }
            public bool InStoreWithdrawalsAllowed { get; set; }
            public bool CheckWithdrawalsAllowed { get; set; }
            public bool ATMWithdrawalsAllowed { get; set; }

            public IState CreateDomainObject();
            public Domain.BankAccount DomainObject { get; }
        }

        public int ID { get; set; }
        public int OwnerID { get; set; }
        public User Owner { get; set; }
        public uint Balance
        {
            get => _state.Balance;
            set => _state.Balance = value;
        }
        public bool TransferWithdrawalsAllowed
        {
            get => _state.TransferWithdrawalsAllowed;
            set => _state.TransferWithdrawalsAllowed = value;
        }
        public bool CheckWithdrawalsAllowed
        {
            get => _state.CheckWithdrawalsAllowed;
            set => _state.CheckWithdrawalsAllowed = value;
        }
        public bool ATMWithdrawalsAllowed
        {
            get => _state.ATMWithdrawalsAllowed;
            set => _state.ATMWithdrawalsAllowed = value;
        }

        private IState _state;

        public BankAccount() => _state = new Initializing();
        public BankAccount(Domain.BankAccount domainObject) => _state = new Sealed(domainObject);

        public Domain.BankAccount DomainObject
        {
            get
            {
                _state = _state.CreateDomainObject();
                return _state.DomainObject;
            }
        }
    }
}
