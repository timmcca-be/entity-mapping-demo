using EntityMappingDemo.Domain;
using System;

namespace EntityMappingDemo.Infrastructure.Users.BankAccounts.States
{
    internal class Sealed : BankAccount.IState
    {
        public Sealed(
            uint balance,
            bool transferWithdrawalsAllowed,
            bool inStoreWithdrawalsAllowed,
            bool checkWithdrawalsAllowed,
            bool atmWithdrawalsAllowed)
        {
            var withdrawalTypes = WithdrawalType.None;
            if (transferWithdrawalsAllowed)
            {
                withdrawalTypes |= WithdrawalType.Transfer;
            }
            if (inStoreWithdrawalsAllowed)
            {
                withdrawalTypes |= WithdrawalType.InStore;
            }
            if (checkWithdrawalsAllowed)
            {
                withdrawalTypes |= WithdrawalType.Check;
            }
            if (atmWithdrawalsAllowed)
            {
                withdrawalTypes |= WithdrawalType.ATM;
            }
            DomainObject = new(balance, withdrawalTypes);
        }

        public Sealed(Domain.BankAccount domainObject) => DomainObject = domainObject;

        public uint Balance
        {
            get => DomainObject.Balance;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool TransferWithdrawalsAllowed
        {
            get => (DomainObject.AllowedWithdrawalTypes & WithdrawalType.Transfer) == WithdrawalType.Transfer;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool InStoreWithdrawalsAllowed
        {
            get => (DomainObject.AllowedWithdrawalTypes & WithdrawalType.InStore) == WithdrawalType.InStore;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool CheckWithdrawalsAllowed
        {
            get => (DomainObject.AllowedWithdrawalTypes & WithdrawalType.Check) == WithdrawalType.Check;
            set => throw new InvalidOperationException("Entity is sealed");
        }
        public bool ATMWithdrawalsAllowed
        {
            get => (DomainObject.AllowedWithdrawalTypes & WithdrawalType.ATM) == WithdrawalType.ATM;
            set => throw new InvalidOperationException("Entity is sealed");
        }

        public BankAccount.IState CreateDomainObject() => this;
        public Domain.BankAccount DomainObject { get; }
    }
}
