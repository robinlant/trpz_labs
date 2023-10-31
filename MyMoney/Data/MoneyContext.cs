using Microsoft.EntityFrameworkCore;
using MyMoney.Entities;

namespace MyMoney.Data;

public class MoneyContext : DbContext
{
	public MoneyContext(DbContextOptions<MoneyContext> ctx) : base(ctx){}

	public DbSet<Transaction> Transactions { get; set; } = null!;
	public DbSet<Account> Accounts { get; set; } = null!;
	public DbSet<User> Users { get; set; } = null!;
	public DbSet<Invite> Invites { get; set; } = null!;
	public DbSet<UserAccess> UserAccesses { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
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