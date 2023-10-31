using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoney.Entities;

public class RepeatingTransaction
{
	public int Id { get; set; }

	[StringLength(50)]
	public string Name { get; set; } = null!;

	[StringLength(500)]
	public string? Description { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public decimal Amount { get; set; }

	public Frequency Frequency { get; set; }

	public DateTime StartDate { get; set; }

	public DateTime? EndDate { get; set; }

	public TransactionType Type { get; set; }

	public ExpenseCategory? ExpenseCategory { get; set; }

	public IncomeCategory? IncomeCategory { get; set; }

	public virtual User MadeBy { get; set; } = null!;
	public virtual Account Account { get; set; } = null!;
	public virtual List<Transaction> Transactions { get; set; } = new List<Transaction>();
}