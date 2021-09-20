using System;

namespace EntityMappingDemo.Infrastructure.Users
{
    public class Initializing : User.IState
    {
        public string Name { get; set; }
        public uint CheckingBalance { get; set; }
        public uint SavingsBalance { get; set; }

        public User.IState CreateDomainObject() => new Sealed(new(Name, new(CheckingBalance), new(SavingsBalance)));
        public Domain.User DomainObject => throw new InvalidOperationException("Domain object not created");
    }
}
