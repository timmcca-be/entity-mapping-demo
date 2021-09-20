using EntityMappingDemo.Domain;
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
        public bool TransferFromCheckingAllowed
        {
            get => (DomainObject.CheckingAccount.AllowedWithdrawalTypes & WithdrawalType.Transfer) == WithdrawalType.Transfer;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool InStoreWithdrawalFromCheckingAllowed
        {
            get => (DomainObject.CheckingAccount.AllowedWithdrawalTypes & WithdrawalType.InStore) == WithdrawalType.InStore;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool CheckWithdrawalFromCheckingAllowed
        {
            get => (DomainObject.CheckingAccount.AllowedWithdrawalTypes & WithdrawalType.Check) == WithdrawalType.Check;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool ATMWithdrawalFromCheckingAllowed
        {
            get => (DomainObject.CheckingAccount.AllowedWithdrawalTypes & WithdrawalType.ATM) == WithdrawalType.ATM;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool TransferFromSavingsAllowed
        {
            get => (DomainObject.SavingsAccount.AllowedWithdrawalTypes & WithdrawalType.Transfer) == WithdrawalType.Transfer;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool InStoreWithdrawalFromSavingsAllowed
        {
            get => (DomainObject.SavingsAccount.AllowedWithdrawalTypes & WithdrawalType.InStore) == WithdrawalType.InStore;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool CheckWithdrawalFromSavingsAllowed
        {
            get => (DomainObject.SavingsAccount.AllowedWithdrawalTypes & WithdrawalType.Check) == WithdrawalType.Check;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool ATMWithdrawalFromSavingsAllowed
        {
            get => (DomainObject.SavingsAccount.AllowedWithdrawalTypes & WithdrawalType.ATM) == WithdrawalType.ATM;
            set => throw new InvalidOperationException("Entity is sealed");
        }
    }
}
