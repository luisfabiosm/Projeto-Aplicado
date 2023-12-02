namespace Domain.Core.Models.Entities
{
    public record User
    {
        public string realm { get; set; }
        public string clientid { get; set; }
        public string sysusername { get; set; }
        public string syspassword { get; set; }
        public DateTime createdat { get; set; }
        public bool isactive { get; set; }
        public string email { get; set; }
        public string identityuserinfo { get; set; }



    }


}
