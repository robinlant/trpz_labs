	using System.ComponentModel.DataAnnotations;

	namespace MyMoney.Entities;

	public class User
	{
		public int Id { get; set; }

		[Required]
		[StringLength(150)]
		public string Email { get; set; } = null!;

		[Required]
		[StringLength(50)]
		public string Username { get; set; } = null!;

		[Required]
		public string Password { get; set; } = null!;

		[Required]
		public DateTime JoinDate { get; set; }

		[Required]
		[StringLength(3)]
		public string DefaultCurrency { get; set; } = null!;

		public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

		public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

		public virtual ICollection<Invite> SentInvites { get; set; } = new List<Invite>();

		public virtual ICollection<Invite> ReceivedInvites { get; set; } = new List<Invite>();

		public virtual ICollection<UserAccess> UserAccesses { get; set; } = new List<UserAccess>();

}