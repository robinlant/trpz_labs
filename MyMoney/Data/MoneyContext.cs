using Microsoft.EntityFrameworkCore;
using MyMoney.Entities;

namespace MyMoney.Data;

public class MoneyContext : DbContext
{
	public MoneyContext(DbContextOptions<MoneyContext> ctx) : base(ctx){}

	public DbSet<RepeatingTransaction> RepeatingTransactions { get; set; } = null!;
	public DbSet<Transaction> Transactions { get; set; } = null!;
	public DbSet<Account> Accounts { get; set; } = null!;
	public DbSet<User> Users { get; set; } = null!;
	public DbSet<Invite> Invites { get; set; } = null!;
	public DbSet<UserAccess> UserAccesses { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//TRANSACTION TO USER
		modelBuilder.Entity<Transaction>()
			.HasOne(i => i.MadeBy)
			.WithMany(a => a.Transactions)
			.OnDelete(DeleteBehavior.SetNull);

		//EMAIL UNIQUENESS
		modelBuilder.Entity<User>()
			.HasIndex(u => u.Email)
			.IsUnique();

		//TRANSACTION TO REPEATING TRANSACTION
		modelBuilder.Entity<Transaction>()
			.HasOne(i => i.RepeatingTransaction)
			.WithMany(a => a.Transactions)
			.OnDelete(DeleteBehavior.SetNull);

		//INVITE
		modelBuilder.Entity<Invite>()
			.HasOne(i => i.Account)
			.WithMany(a => a.Invites)
			.IsRequired()
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Invite>()
			.HasOne(i => i.User)
			.WithMany(u => u.SentInvites)
			.IsRequired()
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Invite>()
			.HasOne(i => i.InvitedUser)
			.WithMany(u => u.ReceivedInvites)
			.IsRequired()
			.OnDelete(DeleteBehavior.Cascade);
	}
}