
using Domain.Core.Base;

namespace Domain.Core.Models.Settings
{
    public record ConnectionSettings
    {
        public string Cluster { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; } = 20;

        public string GetConnectionString()
        {
            var crypt = new Crypt();
            string _Password = crypt.DecryptDESFunction(Password, "zuu|@??(0ntr0|");
            return $"Data Source={Cluster};Initial Catalog={Database};Persist Security Info=True;User ID={Username};Password={_Password}";
        }

        ~ConnectionSettings()
        {
            Cluster = null;
            Username = null;
            Password = null;
            Database = null;
        }
    }
}
