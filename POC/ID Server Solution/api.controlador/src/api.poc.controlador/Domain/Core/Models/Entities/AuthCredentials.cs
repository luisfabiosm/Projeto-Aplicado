using Domain.UseCases.GetUserAuthorization;
using System.Runtime.InteropServices;

namespace Domain.Core.Models.Entities
{
    public record AuthCredentials
    {
        public string Realm { get; internal set; }
        public string GrantType { get; internal set; }
        public string ClientId { get; internal set; }
        public string Username { get; internal set; }
        public string Password { get; internal set; }
        public string Secret { get; internal set; }
      

        public AuthCredentials(TransactionGetAuthorization transaction, Client client )
        {
            this.GrantType = "password";
            this.ClientId = transaction.ClientId;
            this.Username = transaction.UserRequest;
            this.Password = transaction.PassworRequest;
            this.Realm = transaction.Realm;
            this.Secret = client.secret;
        }

        ~AuthCredentials()
        {
            GrantType = null;
            ClientId = null;
            Username = null;
            Password = null;
            Realm = null;
            Secret = null;
        }
    }
}
