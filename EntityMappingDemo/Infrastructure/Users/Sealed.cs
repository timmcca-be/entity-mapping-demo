using System;

namespace EntityMappingDemo.Infrastructure.Users
{
    public class Sealed : User.IState
    {
        public Sealed(Domain.User domainObject)
        {
            DomainObject = domainObject;
        }

        public string Name
        {
            get => DomainObject.Name;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public uint CheckingBalance
        {
            get => DomainObject.CheckingAccount.Balance;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public uint SavingsBalance
        {
            get => DomainObject.SavingsAccount.Balance;
            set => throw new InvalidOperationException("Entity is sealed");
        }

        public User.IState CreateDomainObject() => this;
        public Domain.User DomainObject { get; }
    }
}
