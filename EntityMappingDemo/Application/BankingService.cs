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

        public async Task OpenAccount(string name)
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

        public async Task DepositToChecking(int userID, uint amount)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.DepositToChecking(amount);
            await _unitOfWork.Commit();
        }

        public async Task WithdrawFromChecking(int userID, uint amount, WithdrawalType type)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.WithdrawFromChecking(amount, type);
            await _unitOfWork.Commit();
        }

        public async Task DepositToSavings(int userID, uint amount)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.DepositToSavings(amount);
            await _unitOfWork.Commit();
        }

        public async Task WithdrawFromSavings(int userID, uint amount, WithdrawalType type)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.WithdrawFromSavings(amount, type);
            await _unitOfWork.Commit();
        }

        public async Task TransferToChecking(int userID, uint amount)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.TransferToChecking(amount);
            await _unitOfWork.Commit();
        }

        public async Task TransferToSavings(int userID, uint amount)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.TransferToSavings(amount);
            await _unitOfWork.Commit();
        }

        public async Task AllowFromSavings(int userID, WithdrawalType withdrawalType)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.AllowFromSavings(withdrawalType);
            await _unitOfWork.Commit();
        }

        public async Task DisallowFromSavings(int userID, WithdrawalType withdrawalType)
        {
            var user = await _unitOfWork.UserRepository.Get(userID);
            user.DisallowFromSavings(withdrawalType);
            await _unitOfWork.Commit();
        }
    }
}
