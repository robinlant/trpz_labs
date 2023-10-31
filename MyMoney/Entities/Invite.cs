namespace MyMoney.Entities;

public class Invite
{
	public int Id { get; set; }

	public virtual Account Account { get; set; } = null!;

	public virtual User User { get; set; } = null!;

	public virtual User InvitedUser { get; set; } = null!;
}