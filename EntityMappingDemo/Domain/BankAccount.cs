using EntityMappingDemo.Domain.Common;
using System;

namespace EntityMappingDemo.Domain
{
    public class BankAccount : IValueObject
    {
        public uint Balance { get; }
        public WithdrawalType AllowedWithdrawalTypes { get; } = ~WithdrawalType.None;

        public BankAccount(uint balance, WithdrawalType allowedWithdrawalTypes)
        {
            Balance = balance;
            AllowedWithdrawalTypes = allowedWithdrawalTypes;
        }

        public BankAccount Deposit(uint amount) => new BankAccount(Balance + amount, AllowedWithdrawalTypes);

        public BankAccount Withdraw(uint amount, WithdrawalType type)
        {
            if ((AllowedWithdrawalTypes & type) != type)
            {
                throw new InvalidOperationException("This withdrawal type is not allowed on this account");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Cannot overdraw account");
            }
            return new BankAccount(Balance - amount, AllowedWithdrawalTypes);
        }

        public BankAccount Allow(WithdrawalType type) =>
            new(Balance, AllowedWithdrawalTypes | type);

        public BankAccount Disallow(WithdrawalType type) =>
            new(Balance, AllowedWithdrawalTypes & ~type);
    }
}
