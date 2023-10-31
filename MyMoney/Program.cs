using Microsoft.EntityFrameworkCore;
using MyMoney.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MoneyContext");
if (string.IsNullOrEmpty(connectionString))
{
	throw new InvalidOperationException("The connection string 'MoneyContext' was not found.");
}
builder.Services.AddDbContext<MoneyContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.Run();