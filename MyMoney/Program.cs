

using MyMoney.Data.Extensions;
using MyMoney.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration)
				.AddRepositories();

var app = builder.Build();

await app.Services.InitializeDb();

app.MapGetEndpoints();

app.Run();