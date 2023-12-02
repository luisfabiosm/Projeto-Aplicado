using Domain.Core.Enums;

namespace Domain.Core.Models.Entities
{
    public record LogTransaction
    {

        public DateTime tranrealdate { get; set; }
        public string tranlogid { get; set; }
        public int trancode { get; set; }
        public string transourceapp { get; set; }
        public string tranrequestinfo { get; set; }
        public string trandetailinfo { get; set; }
        public string tranresponseinfo { get; set; }
        public EnumStatusLog transtatus { get; set; }

        public LogTransaction()
        {

        }

        public LogTransaction(DateTime date, int code)
        {
            trancode = code;
            tranrealdate = date;
            transtatus = EnumStatusLog.PENDING;
            tranlogid = Guid.NewGuid().ToString();
        }


    }
}
