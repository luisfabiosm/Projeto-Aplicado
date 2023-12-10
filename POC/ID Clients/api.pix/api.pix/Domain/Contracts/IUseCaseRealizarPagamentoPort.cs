using Domain.Models.Transacao;

namespace Domain.Contracts
{
    public interface IUseCaseRealizarPagamentoPort
    {
        Task<IResult> ProcessarTransacao(TransacaoRealizarPagamento transacao);
    }
}
