using System.ComponentModel.DataAnnotations;

namespace MyMoney.Entities;

public class Invite
{
	public int Id { get; set; }

	[Required]
	public virtual Account Account { get; set; } = null!;

	[Required]
	public virtual User User { get; set; } = null!;

	[Required]
	public virtual User InvitedUser { get; set; } = null!;
}