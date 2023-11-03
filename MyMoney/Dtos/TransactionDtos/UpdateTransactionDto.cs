using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyMoney.Entities;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos;

public class UpdateTransactionDto
{
	[StringLength(50)]
	[NoWhitespaceOnly]
	public string? Name { get; set; } = null!;

	[StringLength(500)]
	[NoWhitespaceOnly]
	public string? Description { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal? Amount { get; set; }

	public TransactionType? Type { get; set; }

	public ExpenseCategory? ExpenseCategory { get; set; }

	public IncomeCategory? IncomeCategory { get; set; }
}