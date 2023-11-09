using MyMoney.Entities;

namespace MyMoney.Repositories.Interfaces;

public interface IUserRepository
{
	Task<User?> GetByIdAsync(int id);
	Task<User?> GetByEmailAsync(string email);
	Task CreateAsync(User createdUser);
	Task UpdateAsync(User updatedUser);
	Task DeleteByIdAsync(int id);
	Task<User?> LoginAsync(string email, string password);
}