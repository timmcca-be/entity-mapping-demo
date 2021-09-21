using EntityMappingDemo.Domain.Common;
using System;

namespace EntityMappingDemo.Domain
{
    public class BankAccount : IEntity
    {
        public uint Balance { get; private set; }
        public WithdrawalType AllowedWithdrawalTypes { get; private set; } = ~WithdrawalType.None;

        public BankAccount(uint balance, WithdrawalType allowedWithdrawalTypes)
        {
            Balance = balance;
            AllowedWithdrawalTypes = allowedWithdrawalTypes;
        }

        public void Deposit(uint amount) => Balance += amount;

        public void Withdraw(uint amount, WithdrawalType type)
        {
            if ((AllowedWithdrawalTypes & type) != type)
            {
                throw new InvalidOperationException("This withdrawal type is not allowed on this account");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Cannot overdraw account");
            }
            Balance -= amount;
        }

        public void Allow(WithdrawalType type) => AllowedWithdrawalTypes |= type;

        public void Disallow(WithdrawalType type) => AllowedWithdrawalTypes &= ~type;
    }
}
