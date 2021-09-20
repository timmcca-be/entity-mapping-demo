namespace EntityMappingDemo.Infrastructure.Users.BankAccounts
{
    internal class BankAccountPersistenceConverter : IPersistenceConverter<Domain.BankAccount, BankAccount>
    {
        public Domain.BankAccount ToDomainObject(BankAccount persistenceObject) => persistenceObject.DomainObject;
        public BankAccount ToPersistenceObject(Domain.BankAccount domainObject) => new BankAccount(domainObject);
    }
}
