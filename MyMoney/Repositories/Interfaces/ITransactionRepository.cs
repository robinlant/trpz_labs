using MyMoney.Entities;

namespace MyMoney.Repositories.Interfaces;

public interface ITransactionRepository
{
	Task<List<Transaction>> GetAllByAccountIdAsync(int id);
	Task<Transaction?> GetByIdAsync(int id);
	Task CreateAsync(Transaction createdTransaction);
	Task UpdateAsync(Transaction updatedTransaction);
	Task DeleteByIdAsync(int id);
}