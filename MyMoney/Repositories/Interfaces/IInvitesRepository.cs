using MyMoney.Entities;

namespace MyMoney.Repositories.Interfaces;

public interface IInvitesRepository
{
	Task<List<Invite>> GetAllReceivedByUserIdAsync(int id);
	Task<List<Invite>> GetAllSentByUserIdAsync(int id);
	Task<Invite?> GetIdAsync(int id);
	Task CreateAsync(Invite createdInvite);
	Task UpdateAsync(Invite updatedInvite);
	Task DeleteByIdAsync(int id);
}