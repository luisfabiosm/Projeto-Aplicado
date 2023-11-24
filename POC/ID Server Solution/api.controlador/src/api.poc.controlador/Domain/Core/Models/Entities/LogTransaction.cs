using Domain.Core.Enums;

namespace Domain.Core.Models.Entities
{
    public record LogTransaction
    {

        public DateTime TranRealDate { get; private set; }
        public Guid TranLogID { get; private set; }
        public int TranCode { get; set; }
        public string TranSourceApp { get; set; }
        public string TranRequestInfo { get; set; }
        public string TranDetailInfo { get; set; }
        public string TranResponseInfo { get; set; }
        public EnumStatusLog TranStatus { get; set; }

        public LogTransaction(DateTime date, int code)
        {
            this.TranCode = code;
            this.TranRealDate = date;
            this.TranStatus = EnumStatusLog.PENDING;
            this.TranLogID = Guid.NewGuid();
        }

     
    }
}
