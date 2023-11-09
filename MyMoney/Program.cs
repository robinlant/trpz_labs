
using MyMoney.Data.Extensions;
using MyMoney.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("cookie").AddCookie("cookie");
builder.Services.AddDbContext(builder.Configuration)
	.AddRepositories();


var app = builder.Build();

await app.Services.InitializeDb();

app.UseAuthentication();

app.MapGetEndpoints();

app.Run();