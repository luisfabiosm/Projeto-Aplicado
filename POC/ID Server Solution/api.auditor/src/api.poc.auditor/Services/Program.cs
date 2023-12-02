using Adapters.Inbound.RestAdapters.Configuration;
using Services.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();
app.UseAPIExtensions();
app.Run();