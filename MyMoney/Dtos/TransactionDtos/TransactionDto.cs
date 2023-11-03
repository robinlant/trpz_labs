using System.ComponentModel.DataAnnotations;
using MyMoney.Entities;

namespace MyMoney.Dtos;

public class TransactionDto
{
	[Required]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = null!;

	[Required]
	public decimal Amount { get; set; }

	[Required]
	public TransactionType Type { get; set; }

	public string? Description { get; set; }

	public ExpenseCategory? ExpenseCategory { get; set; }

	public IncomeCategory? IncomeCategory { get; set; }

	public int? MadeByUserId { get; set; }

	public int? RepeatingTransactionId { get; set; }
}