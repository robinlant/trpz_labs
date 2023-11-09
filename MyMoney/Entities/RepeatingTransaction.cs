using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoney.Entities;

public class RepeatingTransaction
{
	public int Id { get; set; }

	[Required]
	[StringLength(50)]
	public string Name { get; set; } = null!;

	[StringLength(500)]
	public string? Description { get; set; }

	[Required]
	[Column(TypeName = "decimal(18,2)")]
	public decimal Amount { get; set; }

	[Required]
	public Frequency Frequency { get; set; }

	[Required]
	public DateTime StartDate { get; set; }

	public DateTime? EndDate { get; set; }

	[Required]
	public TransactionType Type { get; set; }

	public ExpenseCategory? ExpenseCategory { get; set; }

	public IncomeCategory? IncomeCategory { get; set; }


	[Required]
	public virtual Account Account { get; set; } = null!;
	public virtual User? MadeBy { get; set; } // only if user gets deleted MadeBy => null
	public virtual List<Transaction> Transactions { get; set; } = new List<Transaction>();
}