using Fina.Api.Data;
using Fina.Api.Services;
using Fina.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinantialContext")));

builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<ITransactionServices, TransactionServices>();

var app = builder.Build();

app.MapGet("/", () => "Api executando com Sucesso!");

app.Run();