using EntityMappingDemo.Domain.Common;

namespace EntityMappingDemo.Domain
{
    public class User : IAggregateRoot
    {
        public string Name { get; }
        public BankAccount CheckingAccount { get; private set; }
        public BankAccount SavingsAccount { get; private set; }

        public User(string name) : this(
            name,
            new(0, ~WithdrawalType.None),
            new(0, ~WithdrawalType.ATM))
        { }

        public User(string name, BankAccount checkingAccount, BankAccount savingsAccount)
        {
            Name = name;
            CheckingAccount = checkingAccount;
            SavingsAccount = savingsAccount;
        }

        public void DepositToChecking(uint amount) => CheckingAccount = CheckingAccount.Deposit(amount);
        public void WithdrawFromChecking(uint amount, WithdrawalType type) =>
            CheckingAccount = CheckingAccount.Withdraw(amount, type);
        public void DepositToSavings(uint amount) => SavingsAccount = SavingsAccount.Deposit(amount);
        public void WithdrawFromSavings(uint amount, WithdrawalType type) =>
            SavingsAccount = SavingsAccount.Withdraw(amount, type);

        public void TransferToChecking(uint amount)
        {
            SavingsAccount = SavingsAccount.Withdraw(amount, WithdrawalType.Transfer);
            CheckingAccount = CheckingAccount.Deposit(amount);
        }

        public void TransferToSavings(uint amount)
        {
            CheckingAccount = CheckingAccount.Withdraw(amount, WithdrawalType.Transfer);
            SavingsAccount = SavingsAccount.Deposit(amount);
        }

        public void AllowFromChecking(WithdrawalType withdrawalType) =>
            CheckingAccount = CheckingAccount.Allow(withdrawalType);

        public void DisallowFromChecking(WithdrawalType withdrawalType) =>
            CheckingAccount = CheckingAccount.Disallow(withdrawalType);

        public void AllowFromSavings(WithdrawalType withdrawalType) =>
            SavingsAccount = SavingsAccount.Allow(withdrawalType);

        public void DisallowFromSavings(WithdrawalType withdrawalType) =>
            SavingsAccount = SavingsAccount.Disallow(withdrawalType);
    }
}
