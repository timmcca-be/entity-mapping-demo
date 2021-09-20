using EntityMappingDemo.Infrastructure.Users.BankAccounts;
using System;
using System.Collections.Generic;

namespace EntityMappingDemo.Infrastructure.Users.States
{
    internal class Initializing : User.IState
    {
        public string Name { get; set; }
        public List<BankAccount> BankAccounts { get; set; }

        public User.IState CreateDomainObject() => new Sealed(Name, BankAccounts);

        public Domain.User DomainObject => throw new InvalidOperationException("Domain object not created");
    }
}
