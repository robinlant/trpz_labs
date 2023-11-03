using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyMoney.Entities;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos;

public class UpdateRepTransactionDto
{
	[StringLength(50)]
	[NoWhitespaceOnly]
	public string? Name { get; set; } = null!;

	[Column(TypeName = "decimal(18,2)")]
	public decimal? Amount { get; set; }

	[Required]
	public TransactionType? Type { get; set; }

	[StringLength(500)]
	public string? Description { get; set; }

	public ExpenseCategory? ExpenseCategory { get; set; }

	public IncomeCategory? IncomeCategory { get; set; }

	public DateTime? EndDate { get; set; }
}