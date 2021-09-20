using EntityMappingDemo.Domain.Common;
using System;

namespace EntityMappingDemo.Domain
{
    public class BankAccount : IValueObject
    {
        public uint Balance { get; }

        public BankAccount(uint balance) => Balance = balance;

        public BankAccount Deposit(uint amount) => new BankAccount(Balance + amount);

        public BankAccount Withdraw(uint amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Cannot overdraw account");
            }
            return new BankAccount(Balance - amount);
        }
    }
}
