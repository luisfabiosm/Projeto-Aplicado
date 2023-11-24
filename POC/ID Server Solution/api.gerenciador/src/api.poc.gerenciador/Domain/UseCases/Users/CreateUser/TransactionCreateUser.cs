using Domain.Core.Base;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.UseCases.ClientApplication.RegisterClientApp;
using System.Text.Json.Serialization;

namespace Domain.UseCases.Users.CreateUser
{
    public record TransactionCreateUser : BaseTransaction
    {

        public RegistrationUser UserInfo { get; internal set; }

        public TransactionCreateUser()
        {

        }

        public TransactionCreateUser(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 750;
            TransactionDate = date;
        }

    }

    public record RegistrationUser
    {
        public string Realm { get; internal set; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public UserCredentials[] Credentials { get; init; }

       
        //public RegistrationUser(string realm, string clientName, string clientid)
        //{
        //    Realm = realm;
        //    ClientName = clientName;
        //    _clientid = clientid;
        //    ScopeInfo = new RegistrationScope(_clientid);
        //}

    }

  
}
