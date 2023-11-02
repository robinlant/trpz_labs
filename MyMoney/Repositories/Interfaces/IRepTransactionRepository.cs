using MyMoney.Entities;

namespace MyMoney.Repositories;

public interface IRepTransactionRepository
{
	Task<List<RepeatingTransaction>> GetAllByAccountIdAsync(int id);
	Task<RepeatingTransaction?> GetByIdAsync(int id);
	Task CreateAsync(RepeatingTransaction createdRepTransaction);
	Task UpdateAsync(RepeatingTransaction updatedRepTransaction);
	Task DeleteByIdAsync(int id);
}