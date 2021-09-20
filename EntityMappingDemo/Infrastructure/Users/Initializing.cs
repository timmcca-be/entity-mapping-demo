using EntityMappingDemo.Domain;
using System;

namespace EntityMappingDemo.Infrastructure.Users
{
    public class Initializing : User.IState
    {
        public string Name { get; set; }
        public uint CheckingBalance { get; set; }
        public bool TransferFromCheckingAllowed { get; set; }
        public bool InStoreWithdrawalFromCheckingAllowed { get; set; }
        public bool CheckWithdrawalFromCheckingAllowed { get; set; }
        public bool ATMWithdrawalFromCheckingAllowed { get; set; }
        public uint SavingsBalance { get; set; }
        public bool TransferFromSavingsAllowed { get; set; }
        public bool InStoreWithdrawalFromSavingsAllowed { get; set; }
        public bool CheckWithdrawalFromSavingsAllowed { get; set; }
        public bool ATMWithdrawalFromSavingsAllowed { get; set; }

        private static WithdrawalType GetWithdrawalTypes(bool transfer, bool inStore, bool check, bool atm)
        {
            var withdrawalTypes = WithdrawalType.None;
            if (transfer)
            {
                withdrawalTypes |= WithdrawalType.Transfer;
            }
            if (inStore)
            {
                withdrawalTypes |= WithdrawalType.InStore;
            }
            if (check)
            {
                withdrawalTypes |= WithdrawalType.Check;
            }
            if (atm)
            {
                withdrawalTypes |= WithdrawalType.ATM;
            }
            return withdrawalTypes;
        }

        public User.IState CreateDomainObject() => new Sealed(new(
            Name,
            new(CheckingBalance, GetWithdrawalTypes(
                TransferFromCheckingAllowed,
                InStoreWithdrawalFromCheckingAllowed,
                CheckWithdrawalFromCheckingAllowed,
                ATMWithdrawalFromCheckingAllowed)),
            new(SavingsBalance, GetWithdrawalTypes(
                TransferFromSavingsAllowed,
                InStoreWithdrawalFromSavingsAllowed,
                CheckWithdrawalFromSavingsAllowed,
                ATMWithdrawalFromSavingsAllowed))));

        public Domain.User DomainObject => throw new InvalidOperationException("Domain object not created");
    }
}
