using Microsoft.EntityFrameworkCore;
using MyMoney.Data;
using MyMoney.Entities;
using MyMoney.Repositories.Interfaces;

namespace MyMoney.Repositories;

public class TransactionRepository : ITransactionRepository
{
	private readonly MoneyContext _dbContext;

	public TransactionRepository(MoneyContext moneyContext)
	{
		_dbContext = moneyContext;
	}

	public async Task<List<Transaction>> GetAllByAccountIdAsync(int id)
	{
		return await _dbContext.Accounts
			.Where(a => a.Id == id)
			.SelectMany(a => a.Transactions)
			.ToListAsync();
	}

	public async Task<List<Transaction>> GetAllByRepTransactionIdAsync(int id)
	{
		return await _dbContext.RepeatingTransactions
			.Where(a => a.Id == id)
			.SelectMany(a => a.Transactions)
			.ToListAsync();
	}

	public async Task<Transaction?> GetByIdAsync(int id)
	{
		return await _dbContext.Transactions.FindAsync(id);
	}

	public async Task UpdateAsync(Transaction updatedTransaction)
	{
		_dbContext.Update(updatedTransaction);
		await _dbContext.SaveChangesAsync();
	}

	public async Task CreateAsync(Transaction createdTransaction)
	{
		_dbContext.Transactions.Add(createdTransaction);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var transaction = await _dbContext.Transactions.FindAsync(id);
		if (transaction is null) return;

		_dbContext.Transactions.Remove(transaction);
		await _dbContext.SaveChangesAsync();
	}
}