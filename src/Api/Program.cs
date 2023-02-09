using Andreani.ARQ.WebHost.Extension;
using Desafio_backend.Application;
using Desafio_backend.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.ConfigureAndreani(app.Environment, app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.Run();
