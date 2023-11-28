namespace Domain.Core.Models.Entities
{
    public record Client
    {

        public string realm { get; set; }
        public string id { get; set; }
        public string clientid { get; set; }
        public string name { get; set; }
        public bool publicclient { get; set; }
        public DateTime createdat { get; set; }
        public bool isactive { get; set; }
        public string email { get; set; }
        public string appidentityconfiguration { get; set; } //KeycloakConfiguration
    }
}
