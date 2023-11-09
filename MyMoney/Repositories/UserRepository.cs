using Microsoft.EntityFrameworkCore;
using MyMoney.Data;
using MyMoney.Entities;
using MyMoney.Repositories.Interfaces;

namespace MyMoney.Repositories;

public class UserRepository : IUserRepository
{
	private readonly MoneyContext _dbContext;

	public UserRepository(MoneyContext moneyContext)
	{
		_dbContext = moneyContext;
	}

	public async Task<User?> GetByIdAsync(int id)
	{
		return await _dbContext.Users.FindAsync(id);
	}

	public async Task<User?> GetByEmailAsync(string email)
	{
		return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
	}

	public async Task CreateAsync(User createdUser)
	{
		_dbContext.Users.Add(createdUser);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(User updatedUser)
	{
		_dbContext.Update(updatedUser);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var user = await _dbContext.Users.FindAsync(id);
		if (user == null) return;

		_dbContext.Users.Remove(user);
		await _dbContext.SaveChangesAsync();
	}

	public async Task<User?> LoginAsync(string email, string password)
	{
		return await _dbContext.Users
			.FirstOrDefaultAsync(u => u.Password == password && u.Email == email);
	}
}