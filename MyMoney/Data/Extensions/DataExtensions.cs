using Microsoft.EntityFrameworkCore;
using MyMoney.Repositories;
using MyMoney.Repositories.Interfaces;

namespace MyMoney.Data.Extensions;

public static class DataExtensions
{
	public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
	{
		var CONNECTION_STRING_NAME = "MoneyContext";

		var connectionString = configuration.GetConnectionString(CONNECTION_STRING_NAME);

		if (string.IsNullOrEmpty(connectionString))
		{
			throw new InvalidOperationException($"The connection string '{CONNECTION_STRING_NAME}' was not found.");
		}

		serviceCollection.AddDbContext<MoneyContext>(options => options.UseNpgsql(connectionString));

		return serviceCollection;
	}

	public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
		serviceCollection.AddScoped<IInvitesRepository, InvitesRepository>();
		serviceCollection.AddScoped<IRepTransactionRepository, RepTransactionRepository>();
		serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
		serviceCollection.AddScoped<IUserAccessRepository, UserAccessRepository>();
		serviceCollection.AddScoped<IUserRepository, UserRepository>();

		return serviceCollection;
	}
}