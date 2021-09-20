using EntityMappingDemo.Domain;
using System;

namespace EntityMappingDemo.Infrastructure.Users.BankAccounts.States
{
    internal class Initializing : BankAccount.IState
    {
        public uint Balance { get; set; }
        public bool TransferWithdrawalsAllowed { get; set; }
        public bool InStoreWithdrawalsAllowed { get; set; }
        public bool CheckWithdrawalsAllowed { get; set; }
        public bool ATMWithdrawalsAllowed { get; set; }

        public BankAccount.IState CreateDomainObject() => new Sealed(
            Balance,
            TransferWithdrawalsAllowed,
            InStoreWithdrawalsAllowed,
            CheckWithdrawalsAllowed,
            ATMWithdrawalsAllowed);

        public Domain.BankAccount DomainObject => throw new InvalidOperationException("Domain object not created");
    }
}
