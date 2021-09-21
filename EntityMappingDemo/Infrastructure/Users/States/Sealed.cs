using EntityMappingDemo.Infrastructure.Users.BankAccounts;
using System;
using System.Collections.Generic;

namespace EntityMappingDemo.Infrastructure.Users.States
{
    internal class Sealed : User.IState
    {
        private readonly PersistenceMapping<Domain.BankAccount, BankAccount> _persistenceMapping =
            new(new BankAccountPersistenceConverter());

        public Sealed(string name, List<BankAccount> bankAccounts)
        {
            DomainObject = new(name, _persistenceMapping.MapToDomain(bankAccounts));
        }

        public Sealed(Domain.User domainObject) => DomainObject = domainObject;

        public string Name
        {
            get => DomainObject.Name;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public List<BankAccount> BankAccounts
        {
            get => _persistenceMapping.MapToPersistence(DomainObject.BankAccounts);
            set => throw new InvalidOperationException("Entity is sealed");
        }


        public User.IState CreateDomainObject() => this;
        public Domain.User DomainObject { get; }
    }
}
