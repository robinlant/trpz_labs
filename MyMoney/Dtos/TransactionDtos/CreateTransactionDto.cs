using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyMoney.Entities;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos;

public class CreateTransactionDto
{
	[Required]
	[StringLength(50)]
	[NoWhitespaceOnly]
	public string Name { get; set; } = null!;

	[StringLength(500)]
	[NoWhitespaceOnly]
	public string? Description { get; set; }

	[Required]
	[Column(TypeName = "decimal(18,2)")]
	public decimal Amount { get; set; }

	[Required]
	public TransactionType Type { get; set; }

	public ExpenseCategory? ExpenseCategory { get; set; }

	public IncomeCategory? IncomeCategory { get; set; }
}