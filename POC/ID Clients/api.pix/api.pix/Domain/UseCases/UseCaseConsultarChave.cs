using Domain.Contracts;
using Domain.Models.Transacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Domain.UseCases
{

 
    public class UseCaseConsultarChave : IUseCaseConsultarChavePort
    {
        public async Task<IResult> ProcessarTransacao(TransacaoConsultarChave transacao)
        {
            return Results.Ok( new
            {
                Banco = 37,
                Agencia = 15,
                Conta = 21187
            });
        }
    }
}
