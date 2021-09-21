namespace EntityMappingDemo.Infrastructure.Users.BankAccounts
{
    internal class BankAccountPersistenceConverter : IPersistenceConverter<Domain.BankAccount, BankAccount>
    {
        public BankAccount ToPersistable(Domain.BankAccount domainObject) => new(domainObject);
    }
}
