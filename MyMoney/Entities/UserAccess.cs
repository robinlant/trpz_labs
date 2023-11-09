using System.ComponentModel.DataAnnotations;

namespace MyMoney.Entities;

public class UserAccess
{
	public int Id { get; set; }

	[Required]
	public UserRole Role { get; set; }

	[Required]
	public virtual User User { get; set; } = null!;

	[Required]
	public virtual Account Account { get; set; } = null!;
}