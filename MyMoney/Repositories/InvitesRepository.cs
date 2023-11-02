using Microsoft.EntityFrameworkCore;
using MyMoney.Data;
using MyMoney.Entities;
using MyMoney.Repositories.Interfaces;

namespace MyMoney.Repositories;

public class InvitesRepository : IInvitesRepository
{
	private readonly MoneyContext _dbContext;

	public InvitesRepository(MoneyContext moneyContext)
	{
		_dbContext = moneyContext;
	}

	public async Task<List<Invite>> GetAllReceivedByUserIdAsync(int id)
	{
		return await _dbContext.Users
			.Where(u => u.Id == id)
			.SelectMany(u => u.ReceivedInvites)
			.ToListAsync();
	}

	public async Task<List<Invite>> GetAllSentByUserIdAsync(int id)
	{
		return await _dbContext.Users
			.Where(u => u.Id == id)
			.SelectMany(u => u.SentInvites)
			.ToListAsync();
	}

	public async Task<Invite?> GetIdAsync(int id)
	{
		return await _dbContext.Invites.FindAsync(id);
	}

	public async Task CreateAsync(Invite createdInvite)
	{
		_dbContext.Invites.Add(createdInvite);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(Invite updatedInvite)
	{
		_dbContext.Update(updatedInvite);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(int id)
	{
		var invite = await _dbContext.Invites.FindAsync(id);
		if (invite is null) return;

		_dbContext.Invites.Remove(invite);
		await _dbContext.SaveChangesAsync();
	}
}