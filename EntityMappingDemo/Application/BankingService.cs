using EntityMappingDemo.Domain;
using EntityMappingDemo.Domain.Common;
using System.Threading.Tasks;

namespace EntityMappingDemo.Application
{
    public class BankingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUser(string name)
        {
            await _unitOfWork.UserRepository.Add(new User(name));
            await _unitOfWork.Commit();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _unitOfWork.UserRepository.Get(id);
            await _unitOfWork.Commit();
            return user;
        }

        public async Task OpenCheckingAccount(int id)
        {
            var user = await _unitOfWork.UserRepository.Get(id);
            user.OpenCheckingAccount();
            await _unitOfWork.Commit();
        }

        public async Task OpenSavingsAccount(int id)
        {
            var user = await _unitOfWork.UserRepository.Get(id);
            user.OpenSavingsAccount();
            await _unitOfWork.Commit();
        }

        public async Task Deposit(int userID, uint accountNumber, uint amount)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.Deposit(accountNumber, amount);
            await _unitOfWork.Commit();
        }

        public async Task Withdraw(int userID, uint accountNumber, uint amount, WithdrawalType type)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.Withdraw(accountNumber, amount, type);
            await _unitOfWork.Commit();
        }

        public async Task Transfer(int userID, uint withdrawalAccountNumber, uint depositAccountNumber, uint amount)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.Transfer(withdrawalAccountNumber, depositAccountNumber, amount);
            await _unitOfWork.Commit();
        }

        public async Task AllowWithdrawalType(int userID, uint accountNumber, WithdrawalType withdrawalType)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.AllowWithdrawalType(accountNumber, withdrawalType);
            await _unitOfWork.Commit();
        }

        public async Task DisallowWithdrawalType(int userID, uint accountNumber, WithdrawalType withdrawalType)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.DisallowWithdrawalType(accountNumber, withdrawalType);
            await _unitOfWork.Commit();
        }

        public async Task DoLotsOfThings(int userID)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.CloseBankAccount(2);
            user.OpenCheckingAccount();
            user.OpenSavingsAccount();
            user.Withdraw(1, 10, WithdrawalType.Check);
            user.Deposit(2, 50);
            user.Deposit(3, 20);
            await _unitOfWork.Commit();
        }
    }
}
