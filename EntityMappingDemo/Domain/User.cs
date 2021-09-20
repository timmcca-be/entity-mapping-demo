using EntityMappingDemo.Domain.Common;
using System.Collections.Generic;

namespace EntityMappingDemo.Domain
{
    public class User : IAggregateRoot
    {
        public string Name { get; }
        public List<BankAccount> BankAccounts { get; }

        public User(string name) : this(name, new()) { }
        public User(string name, List<BankAccount> bankAccounts)
        {
            Name = name;
            BankAccounts = bankAccounts;
        }

        public BankAccount BankAccount(uint accountNumber) => BankAccounts[(int)accountNumber - 1];

        public void Deposit(uint accountNumber, uint amount) =>
            BankAccount(accountNumber).Deposit(amount);
        public void Withdraw(uint accountNumber, uint amount, WithdrawalType type) =>
            BankAccount(accountNumber).Withdraw(amount, type);

        public void Transfer(uint withdrawalAccountNumber, uint depositAccountNumber, uint amount)
        {
            BankAccount(withdrawalAccountNumber).Withdraw(amount, WithdrawalType.Transfer);
            BankAccount(depositAccountNumber).Deposit(amount);
        }

        public void AllowWithdrawalType(uint accountNumber, WithdrawalType withdrawalType) =>
            BankAccount(accountNumber).Allow(withdrawalType);

        public void DisallowWithdrawalType(uint accountNumber, WithdrawalType withdrawalType) =>
            BankAccount(accountNumber).Disallow(withdrawalType);

        public void OpenCheckingAccount() => BankAccounts.Add(new(0, ~WithdrawalType.None));
        public void OpenSavingsAccount() => BankAccounts.Add(new(0, ~WithdrawalType.ATM));

        public void CloseBankAccount(uint accountNumber) => BankAccounts.RemoveAt((int)accountNumber - 1);
    }
}
