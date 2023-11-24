
using TesteKeycloak.net.Interfaces;
using TesteKeycloak.net.Models;
using TesteKeycloak.net.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IKeycloakAPIService, KeycloakAPIService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.MapGet("/Token", async (IKeycloakAPIService keycloakAPIService) =>
{
    var _accessTokenRequest = new AccessTokenRequest
    {
        Username = "admin",
        Password = "admin",
        ClientId = "admin-cli",
        GrantType = "password"
    };

    var retClients = keycloakAPIService.GetAccessTokenAsync(_accessTokenRequest);

    return retClients;

})
.WithName("GetToken");
app.Run();



