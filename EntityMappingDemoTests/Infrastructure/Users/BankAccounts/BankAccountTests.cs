using EntityMappingDemo.Infrastructure.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityMappingDemo.Infrastructure.Users.BankAccounts.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void DomainObject_WithBalance_GeneratesBalance()
        {
            // Arrange
            var bankAccount = new BankAccount
            {
                Balance = 123
            };

            // Act
            var domainObject = bankAccount.DomainObject;
            
            // Assert
            Assert.AreEqual<uint>(123, domainObject.Balance);
        }

        [TestMethod]
        public void DomainObject_WithFlags_GeneratesWithdrawalTypes()
        {
            // Arrange
            var bankAccount = new BankAccount
            {
                TransferWithdrawalsAllowed = true,
                InStoreWithdrawalsAllowed = true,
                CheckWithdrawalsAllowed = false,
                ATMWithdrawalsAllowed = false
            };

            // Act
            var domainObject = bankAccount.DomainObject;

            // Assert
            Assert.AreEqual(
                Domain.WithdrawalType.Transfer | Domain.WithdrawalType.InStore,
                domainObject.AllowedWithdrawalTypes);
        }

        [TestMethod]
        public void DomainObject_OnceGenerated_SealsBalance()
        {
            // Arrange
            var bankAccount = new BankAccount
            {
                Balance = 321,
            };

            // Act
            var domainObject = bankAccount.DomainObject;

            // Assert
            Assert.ThrowsException<EntitySealedException>(() => bankAccount.Balance = 123);
            Assert.AreEqual<uint>(321, bankAccount.Balance);
        }

        [TestMethod]
        public void DomainObject_OnceGenerated_SealsTransferFlag()
        {
            // Arrange
            var bankAccount = new BankAccount
            {
                TransferWithdrawalsAllowed = false,
            };

            // Act
            var domainObject = bankAccount.DomainObject;

            // Assert
            Assert.ThrowsException<EntitySealedException>(() => bankAccount.TransferWithdrawalsAllowed = true);
            Assert.IsFalse(bankAccount.TransferWithdrawalsAllowed);
        }

        [TestMethod]
        public void DomainObject_OnceGenerated_SealsInStoreFlag()
        {
            // Arrange
            var bankAccount = new BankAccount
            {
                InStoreWithdrawalsAllowed = false,
            };

            // Act
            var domainObject = bankAccount.DomainObject;

            // Assert
            Assert.ThrowsException<EntitySealedException>(() => bankAccount.InStoreWithdrawalsAllowed = true);
            Assert.IsFalse(bankAccount.InStoreWithdrawalsAllowed);
        }

        [TestMethod]
        public void DomainObject_OnceGenerated_SealsCheckFlag()
        {
            // Arrange
            var bankAccount = new BankAccount
            {
                CheckWithdrawalsAllowed = false,
            };

            // Act
            var domainObject = bankAccount.DomainObject;

            // Assert
            Assert.ThrowsException<EntitySealedException>(() => bankAccount.CheckWithdrawalsAllowed = true);
            Assert.IsFalse(bankAccount.CheckWithdrawalsAllowed);
        }

        [TestMethod]
        public void DomainObject_OnceGenerated_SealsATMFlag()
        {
            // Arrange
            var bankAccount = new BankAccount
            {
                ATMWithdrawalsAllowed = false,
            };

            // Act
            var domainObject = bankAccount.DomainObject;

            // Assert
            Assert.ThrowsException<EntitySealedException>(() => bankAccount.ATMWithdrawalsAllowed = true);
            Assert.IsFalse(bankAccount.ATMWithdrawalsAllowed);
        }

        [TestMethod]
        public void DomainObject_WhenBalanceUpdated_UpdatesParentBalance()
        {
            // Arrange
            var bankAccount = new BankAccount
            {
                Balance = 123
            };
            var domainObject = bankAccount.DomainObject;

            // Act
            domainObject.Deposit(10);

            // Assert
            Assert.AreEqual<uint>(133, bankAccount.Balance);
        }

        [TestMethod]
        public void DomainObject_WhenWithdrawalTypesUpdated_UpdatesParentFlags()
        {
            // Arrange
            var bankAccount = new BankAccount
            {
                TransferWithdrawalsAllowed = true,
                InStoreWithdrawalsAllowed = true,
                CheckWithdrawalsAllowed = false,
                ATMWithdrawalsAllowed = false
            };
            var domainObject = bankAccount.DomainObject;

            // Act
            domainObject.Disallow(Domain.WithdrawalType.Check);

            // Assert
            Assert.IsFalse(bankAccount.CheckWithdrawalsAllowed);
        }
    }
}