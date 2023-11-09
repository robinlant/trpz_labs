using System.ComponentModel.DataAnnotations;
using MyMoney.Entities;

namespace MyMoney.Dtos;

public record RepTransactionDto
{
	[Required]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = null!;

	[Required]
	public decimal Amount { get; set; }

	[Required]
	public Frequency Frequency { get; set; }

	[Required]
	public DateTime StartDate { get; set; }

	[Required]
	public int AccountId { get; set; }

	[Required]
	public TransactionType Type { get; set; }

	public string? Description { get; set; }

	public ExpenseCategory? ExpenseCategory { get; set; }

	public IncomeCategory? IncomeCategory { get; set; }

	public DateTime? EndDate { get; set; }

	public int? MadeBy { get; set; }
}