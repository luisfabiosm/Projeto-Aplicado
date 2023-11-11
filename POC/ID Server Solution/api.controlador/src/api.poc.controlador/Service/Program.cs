using Adapters.Inbound.RestAdapters.Configuration;
using Service.Configuration;

var builder = WebApplication.CreateBuilder(args);

//IConfiguration configuration = new ConfigurationBuilder()
//                  .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//                  .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
//                  .AddEnvironmentVariables()
//                  .Build();

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();
app.UseAPIExtensions();
app.Run();