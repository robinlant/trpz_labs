namespace MyMoney.Entities;

public class UserAccess
{
	public int Id { get; set; }

	public UserRole Role { get; set; }

	public virtual User User { get; set; } = null!;
	public virtual Account Account { get; set; } = null!;
}