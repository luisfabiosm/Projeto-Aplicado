using Domain.Contracts;
using Domain.Models.Transacao;

namespace Domain.UseCases
{

    

    public class UseCaseRealizarPagamento : IUseCaseRealizarPagamentoPort
    {
        public async Task<IResult> ProcessarTransacao(TransacaoRealizarPagamento transacao)
        {
            throw new NotImplementedException();
        }
    }
}
