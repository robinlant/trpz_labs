

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoney.Entities;



public class Transaction
{
	public int Id { get; set; }

	[StringLength(50)]
	public string Name { get; set; } = null!;

	[Column(TypeName = "decimal(18,2)")]
	public decimal Amount { get; set; }

	public DateTime Date { get; set; }

	public TransactionType Type { get; set; }

	public ExpenseCategory? ExpenseCategory { get; set; }

	public IncomeCategory? IncomeCategory { get; set; }

	public virtual User MadeBy { get; set; } = null!;
	public virtual Account Account { get; set; } = null!;
}