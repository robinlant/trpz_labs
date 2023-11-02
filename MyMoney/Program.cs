

using MyMoney.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration)
				.AddRepositories();

var app = builder.Build();

app.Run();