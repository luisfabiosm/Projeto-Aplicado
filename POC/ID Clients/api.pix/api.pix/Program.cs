

using Domain.Contracts;
using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Models.Transacao;
using Extensions;
using Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDomainAdapter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddKeycloakIDAuth(builder.Configuration, builder);
builder.Services.AddSwaggerAdapter();
builder.Services.AddAuthorization();

var app = builder.Build();


//#Routes

app.MapPost("pix/chave", async (ConsultarChaveRequest request, IUseCaseConsultarChavePort _service) => { await _service.ProcessarTransacao(new TransacaoConsultarChave(request)); })
            .WithTags("Consulta Chave Pix")
            .Accepts<ConsultarChaveRequest>("application/json")
            .Produces<IResult>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status400BadRequest)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


app.MapPost("pix/pagamento", async (RealizarPagamentoRequest request, IUseCaseRealizarPagamentoPort _service) => { await _service.ProcessarTransacao(new TransacaoRealizarPagamento(request)); })
            .WithTags("Pagamento Pix")
            .Accepts<RealizarPagamentoRequest>("application/json")
            .Produces<IResult>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status400BadRequest)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();



if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Development" || app.Environment.EnvironmentName == "Local" || app.Environment.EnvironmentName == "Fabrica")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
