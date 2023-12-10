using Domain.Contracts;
using Domain.Models.Transacao;
using Microsoft.AspNetCore.Http;

namespace Domain.UseCases
{

 
    public class UseCaseConsultarChave : IUseCaseConsultarChavePort
    {
        public async Task<IResult> ProcessarTransacao(TransacaoConsultarChave transacao)
        {
            throw new NotImplementedException();
        }
    }
}
