using Microsoft.EntityFrameworkCore;
using MyMoney.Data;
using MyMoney.Entities;

namespace MyMoney.Repositories;

public class UserAccessRepository : IUserAccessRepository
{
	private readonly MoneyContext _dbContext;

	public UserAccessRepository(MoneyContext moneyContext)
	{
		_dbContext = moneyContext;
	}

	public async Task<List<UserAccess>> GetAllByAccountIdAsync(int id)
	{
		return await _dbContext.Accounts
			.Where(a => a.Id == id)
			.SelectMany(a => a.UserAccesses)
			.ToListAsync();
	}

	public async Task<List<UserAccess>> GetAllByUserIdAsync(int id)
	{
		return await _dbContext.Users
			.Where(u => u.Id == id)
			.SelectMany(u => u.UserAccesses)
			.ToListAsync();
	}

	public async Task<UserAccess?> GetByIdAsync(int id)
	{
		return await _dbContext.UserAccesses.FindAsync(id);
	}

	public async Task CreateAsync(UserAccess createdUserAccess)
	{
		_dbContext.UserAccesses.Add(createdUserAccess);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(UserAccess updatedUserAccess)
	{
		_dbContext.Update(updatedUserAccess);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var userAccess = await _dbContext.UserAccesses.FindAsync(id);
		if (userAccess is null) return;

		_dbContext.UserAccesses.Remove(userAccess);
		await _dbContext.SaveChangesAsync();
	}
}