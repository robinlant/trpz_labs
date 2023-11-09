
using Microsoft.EntityFrameworkCore;
using MyMoney.Data;
using MyMoney.Entities;
using MyMoney.Repositories.Interfaces;

namespace MyMoney.Repositories;

public class AccountRepository : IAccountRepository
{
	private readonly MoneyContext _dbContext;

	public AccountRepository(MoneyContext moneyContext)
	{
		_dbContext = moneyContext;
	}

	public async Task<List<Account>> GetAllByOwnerIdAsync(int ownerId)
	{
		return await _dbContext.Accounts.Where(account => account.Owner.Id == ownerId).ToListAsync();
	}

	public async Task<List<Account>?> GetAllByGuestUserIdAsync(int id)
	{
		return await _dbContext.Users
			.Where(u => u.Id == id)
			.SelectMany(u => u.UserAccesses)
			.Select(ua => ua.Account)
			.ToListAsync();
	}

	public async Task<Account?> GetByIdAsync(int id)
	{
		return await _dbContext.Accounts.FindAsync(id);
	}

	public async Task CreateAsync(Account createdAccount)
	{
		_dbContext.Accounts.Add(createdAccount);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(Account updatedAccount)
	{
		_dbContext.Update(updatedAccount);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var account = await _dbContext.Accounts.FindAsync(id);
		if (account == null) return;

		_dbContext.Accounts.Remove(account);
		await _dbContext.SaveChangesAsync();
	}
}