namespace Domain.Core.Base
{
    public record BaseTransaction
    {

        public string TransactionCode { get; internal set; }
        public DateTime TransactionDate { get; internal set; }



        #region Dados Transacao
        public string? Info { get; internal set; }

        #endregion


        public BaseTransaction()
        {

        }


    }

}
