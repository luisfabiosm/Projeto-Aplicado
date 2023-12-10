namespace Domain.Models.Request
{
    public record ConsultarChaveRequest
    {

        public string Chave { get; set; }
        public int Tipo { get; set; } // 0 - email, 1 - telefone, 2 - cpf\cnpj


        public ConsultarChaveRequest()
        {
            
        }

        public ConsultarChaveRequest(string chave, int tipo)
        {
            Chave = chave;
            Tipo = tipo;
        }
    }
}
