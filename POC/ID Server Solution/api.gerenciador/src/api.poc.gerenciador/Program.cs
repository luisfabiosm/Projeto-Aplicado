using Keycloak.Net;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


  


app.Run();


void teste()
{
    KeycloakClient keynet = new KeycloakClient("","","");

    keynet.createu.
} 