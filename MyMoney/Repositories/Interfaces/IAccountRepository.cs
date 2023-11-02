using MyMoney.Entities;

namespace MyMoney.Repositories.Interfaces;

public interface IAccountRepository
{
	Task<List<Account>> GetAllByOwnerIdAsync(int ownerId);
	Task<List<Account>?> GetAllByGuestUserIdAsync(int id);
	Task<Account?> GetByIdAsync(int id);
	Task CreateAsync(Account createdAccount);
	Task UpdateAsync(Account updatedAccount);
	Task DeleteByIdAsync(int id);
}