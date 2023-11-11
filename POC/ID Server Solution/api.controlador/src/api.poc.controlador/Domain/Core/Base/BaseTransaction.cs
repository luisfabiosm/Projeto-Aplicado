using Domain.Core.Models.Entities;

namespace Domain.Core.Base
{
    public record BaseTransaction
    {

        public int TransactionCode { get;  internal set; }
        public DateTime TransactionDate { get; internal set; }
        public LogTransaction TransactionLog { get; set; }

        #region Dados Transacao
        public string? Info { get; internal set; }

        #endregion

        public BaseTransaction(DateTime date, int code)
        {
            this.TransactionCode = code;
            this.TransactionDate = date;
            this.TransactionLog = new LogTransaction(date, code);
        }

        public BaseTransaction()
        {

        }


    }

}
