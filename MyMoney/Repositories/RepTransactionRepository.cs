using Microsoft.EntityFrameworkCore;
using MyMoney.Data;
using MyMoney.Entities;

namespace MyMoney.Repositories;

public class RepTransactionRepository : IRepTransactionRepository
{
	private readonly MoneyContext _dbContext;

	public RepTransactionRepository(MoneyContext moneyContext)
	{
		_dbContext = moneyContext;
	}

	public async Task<List<RepeatingTransaction>> GetAllByAccountIdAsync(int id)
	{
		return await _dbContext.Accounts
			.Where(a => a.Id == id)
			.SelectMany(a => a.RepeatingTransactions)
			.ToListAsync();
	}

	public async Task<RepeatingTransaction?> GetByIdAsync(int id)
	{
		return await _dbContext.RepeatingTransactions.FindAsync(id);
	}

	public async Task CreateAsync(RepeatingTransaction createdRepTransaction)
	{
		_dbContext.RepeatingTransactions.Add(createdRepTransaction);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(RepeatingTransaction updatedRepTransaction)
	{
		_dbContext.Update(updatedRepTransaction);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var repTransaction = await _dbContext.RepeatingTransactions.FindAsync(id);
		if (repTransaction is null) return;

		_dbContext.RepeatingTransactions.Remove(repTransaction);
		await _dbContext.SaveChangesAsync();
	}
}