
using Domain.Models.Request;

namespace Domain.Models.Transacao
{
    public record TransacaoRealizarPagamento
    {
        public int Banco { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public decimal Valor { get; set; }


        public TransacaoRealizarPagamento(RealizarPagamentoRequest request)
        {
            this.Banco = request.Banco;
            this.Agencia = request.Agencia;
            this.Conta = request.Conta;
            this.Valor = request.Valor;
        }
    }


    }
}
