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

        public async Task<IUserID> CreateUser(string name)
        {
            var id = await _unitOfWork.UserRepository.Add(new User(name));
            await _unitOfWork.Commit();
            return id;
        }

        public async Task<User> GetUser(IUserID userID)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            await _unitOfWork.Commit();
            return user;
        }

        public async Task OpenCheckingAccount(IUserID userID)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.OpenCheckingAccount();
            await _unitOfWork.Commit();
        }

        public async Task OpenSavingsAccount(IUserID userID)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.OpenSavingsAccount();
            await _unitOfWork.Commit();
        }

        public async Task Deposit(IUserID userID, uint accountNumber, uint amount)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.Deposit(accountNumber, amount);
            await _unitOfWork.Commit();
        }

        public async Task Withdraw(IUserID userID, uint accountNumber, uint amount, WithdrawalType type)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.Withdraw(accountNumber, amount, type);
            await _unitOfWork.Commit();
        }

        public async Task Transfer(IUserID userID, uint withdrawalAccountNumber, uint depositAccountNumber, uint amount)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.Transfer(withdrawalAccountNumber, depositAccountNumber, amount);
            await _unitOfWork.Commit();
        }

        public async Task AllowWithdrawalType(IUserID userID, uint accountNumber, WithdrawalType withdrawalType)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.AllowWithdrawalType(accountNumber, withdrawalType);
            await _unitOfWork.Commit();
        }

        public async Task DisallowWithdrawalType(IUserID userID, uint accountNumber, WithdrawalType withdrawalType)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.DisallowWithdrawalType(accountNumber, withdrawalType);
            await _unitOfWork.Commit();
        }

        public async Task DoLotsOfThings(IUserID userID)
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
