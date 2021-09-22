using EntityMappingDemo.Infrastructure.Persistence;
using EntityMappingDemo.Infrastructure.Users.BankAccounts;
using EntityMappingDemo.Infrastructure.Users.States;
using System.Collections.Generic;

namespace EntityMappingDemo.Infrastructure.Users
{
    public class User : IPersistable<Domain.User>
    {
        public interface IState
        {
            public string Name { get; set; }
            public List<BankAccount> BankAccounts { get; set; }

            public IState CreateDomainObject();
            public Domain.User DomainObject { get; }
        }

        public int ID { get; set; }
        public string Name
        {
            get => _state.Name;
            set => _state.Name = value;
        }
        public List<BankAccount> BankAccounts
        {
            get => _state.BankAccounts;
            set => _state.BankAccounts = value;
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
