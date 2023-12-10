using Domain.Contracts;
using Domain.Models.Transacao;

namespace Domain.UseCases
{

    

    public class UseCaseRealizarPagamento : IUseCaseRealizarPagamentoPort
    {
        public async Task<IResult> ProcessarTransacao(TransacaoRealizarPagamento transacao)
        {
            return Results.Ok("PIX realizado com sucesso.");
        }
    }
}
