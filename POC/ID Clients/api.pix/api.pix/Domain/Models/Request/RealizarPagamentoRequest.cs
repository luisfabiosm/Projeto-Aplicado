namespace Domain.Models.Request
{
    public record RealizarPagamentoRequest
    {
        public int Banco { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public decimal Valor { get; set; }

        public RealizarPagamentoRequest()
        {
            
        }

        public RealizarPagamentoRequest(int banco, int agencia, int conta, decimal vcalor)
        {
            this.Banco = banco;
            this.Agencia = agencia;
            this.Conta = conta;
            this.Valor = Valor;
        }
    }
}
