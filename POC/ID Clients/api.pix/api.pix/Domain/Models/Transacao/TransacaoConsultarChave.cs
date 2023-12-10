
using Domain.Models.Request;

namespace Domain.Models.Transacao
{
    public record TransacaoConsultarChave
    {
        public string Chave { get; set; }
        public int Tipo { get; set; } // 0 - email, 1 - telefone, 2 - cpf\cnpj


        public TransacaoConsultarChave(ConsultarChaveRequest request)
        {
            this.Chave = request.Chave;
            this.Tipo = request.Tipo;
        }


    }
}
