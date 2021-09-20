using EntityMappingDemo.Domain.Common;

namespace EntityMappingDemo.Domain
{
    public class User : IAggregateRoot
    {
        public string Name { get; }
        public BankAccount CheckingAccount { get; private set; }
        public BankAccount SavingsAccount { get; private set; }

        public User(string name) : this(name, new(0), new(0)) { }

        public User(string name, BankAccount checkingAccount, BankAccount savingsAccount)
        {
            Name = name;
            CheckingAccount = checkingAccount;
            SavingsAccount = savingsAccount;
        }

        public void DepositToChecking(uint amount) => CheckingAccount = CheckingAccount.Deposit(amount);
        public void DepositToSavings(uint amount) => SavingsAccount = SavingsAccount.Deposit(amount);

        public void TransferToChecking(uint amount)
        {
            SavingsAccount = SavingsAccount.Withdraw(amount);
            CheckingAccount = CheckingAccount.Deposit(amount);
        }

        public void TransferToSavings(uint amount)
        {
            CheckingAccount = CheckingAccount.Withdraw(amount);
            SavingsAccount = SavingsAccount.Deposit(amount);
        }
    }
}
