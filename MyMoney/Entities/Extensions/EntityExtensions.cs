using MyMoney.Dtos;

namespace MyMoney.Entities.Extensions;

public static class EntityExtensions
{
	public static AccountDto AsDto(this Account account)
	{
		return new AccountDto
		{
			Id = account.Id,
			Name = account.Name,
			CurrencyCode = account.CurrencyCode,
			OwnerId = account.Owner.Id,
			CreationDate = account.CreationDate,
			Description = account.Description
		};
	}

	public static InviteDto AsDto(this Invite invite)
	{
		return new InviteDto
		{
			Id = invite.Id,
			AccountId = invite.Account.Id,
			SenderId = invite.User.Id,
			InvitedUserId = invite.InvitedUser.Id
		};
	}

	public static RepTransactionDto AsDto(this RepeatingTransaction repTransaction)
	{
		return new RepTransactionDto
		{
			Id = repTransaction.Id,
			Name = repTransaction.Name,
			Amount = repTransaction.Amount,
			Frequency = repTransaction.Frequency,
			StartDate = repTransaction.StartDate,
			AccountId = repTransaction.Account.Id,
			Type = repTransaction.Type,
			Description = repTransaction.Description,
			ExpenseCategory = repTransaction.ExpenseCategory,
			IncomeCategory = repTransaction.IncomeCategory,
			EndDate = repTransaction.EndDate,
			MadeBy = repTransaction.MadeBy?.Id
		};
	}

	public static TransactionDto AsDto(this Transaction transaction)
	{
		return new TransactionDto
		{
			Id = transaction.Id,
			Name = transaction.Name,
			Amount = transaction.Amount,
			Type = transaction.Type,
			Description = transaction.Description,
			ExpenseCategory = transaction.ExpenseCategory,
			IncomeCategory = transaction.IncomeCategory,
			MadeByUserId = transaction.MadeBy?.Id,
			RepeatingTransactionId = transaction.RepeatingTransaction?.Id
		};
	}

	public static UserDto AsDto(this User user)
	{
		return new UserDto
		{
			Id = user.Id,
			Email = user.Email,
			Username = user.Username,
			JoinDate = user.JoinDate,
			DefaultCurrency = user.DefaultCurrency
		};
	}

	public static UserAccessDto AsDto(this UserAccess userAccess)
	{
		return new UserAccessDto
		{
			Role = userAccess.Role,
			UserId = userAccess.User.Id,
			AccountId = userAccess.Account.Id
		};
	}
}