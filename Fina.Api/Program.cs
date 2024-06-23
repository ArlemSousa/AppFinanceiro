using Fina.Api.Data; // Make sure this namespace is correct
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string connectionString = "Data Source=JARVIS-PC\\SQLEXPRESS;Initial Catalog=FinantialDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

// Use the full type name (Fina.Api.Data.Context) here:
builder.Services.AddDbContext<Fina.Api.Data.AppDbContext>(x => x.UseSqlServer(connectionString));

app.MapGet("/", () => "Api executando com Sucesso!");

app.Run();