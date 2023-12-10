using Domain.Models.Transacao;

namespace Domain.Contracts
{
    public interface IUseCaseConsultarChavePort
    {
        Task<IResult> ProcessarTransacao(TransacaoConsultarChave transacao);
    }

}
