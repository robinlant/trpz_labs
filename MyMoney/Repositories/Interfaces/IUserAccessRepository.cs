using MyMoney.Entities;
namespace MyMoney.Repositories.Interfaces;

public interface IUserAccessRepository
{
	Task<List<UserAccess>> GetAllByAccountIdAsync(int id);
	Task<List<UserAccess>> GetAllByUserIdAsync(int id);
	Task<UserAccess?> GetByIdAsync(int id);
	Task<UserAccess?> GetByUserIdAccountIdAsync(int userId, int accountId);
	Task CreateAsync(UserAccess createdUserAccess);
	Task UpdateAsync(UserAccess updatedUserAccess);
	Task DeleteByIdAsync(int id);
}