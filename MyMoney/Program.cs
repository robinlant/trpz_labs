

using MyMoney.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration)
				.AddRepositories();

var app = builder.Build();

await app.Services.InitializeDb();

app.Run();