using System.ComponentModel.DataAnnotations;

namespace MyMoney.Entities;

public class Account
{
	public int Id { get; set; }

	[Required]
	[StringLength(50)]
	public string Name { get; set; } = null!;

	[Required]
	[StringLength(3)]
	public string CurrencyCode { get; set; } = null!;

	[StringLength(500)]
	public string? Description { get; set; }

	public DateTime CreationDate { get; set; }

	[Required]
	public virtual User Owner { get; set; } = null!;

	public virtual ICollection<RepeatingTransaction> RepeatingTransactions { get; set; } = new List<RepeatingTransaction>();

	public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

	public virtual ICollection<Invite> Invites { get; set; } = new List<Invite>();

	public virtual ICollection<UserAccess> UserAccesses { get; set; } = new List<UserAccess>();
}