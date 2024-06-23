using Fina.Api;
using Fina.Api.Common.Api;
using Fina.Api.Endpoints;
using Fina.Core;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

//só vou chamar o swagger se o ambiente for dev, se for em ambiente de produção não chama
var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();

app.Run();