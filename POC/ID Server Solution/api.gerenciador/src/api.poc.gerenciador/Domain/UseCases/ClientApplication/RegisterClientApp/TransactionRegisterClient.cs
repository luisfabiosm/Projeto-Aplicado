using Domain.Core.Base;
using Domain.Core.Models.Dto;
using Microsoft.AspNetCore.Authentication;

namespace Domain.UseCases.ClientApplication.RegisterClientApp
{
    public record TransactionRegisterClient : BaseTransaction
    {
   
        public RegistrationClient ClientInfo { get; internal set; }

        public TransactionRegisterClient()
        {
                
        }

        public TransactionRegisterClient(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 700;
            TransactionDate = date;
        }


    }


    public struct RegistrationClient
    {
        private string _clientid;
        public string Realm { get; internal set; }
        public string ClientName { get; internal set; }
        public string Description { get; set; }

        public string ClientId
        {
            get { return _clientid; }
            internal set { _clientid = value; }
        }
        public bool ClientAuthentitcation { get; init; } = true;
        public RegistrationScope ScopeInfo { get; private set; }

        public RegistrationClient(string realm, string clientName, string clientid, string description = "")
        {
            Realm = realm;
            ClientName = clientName;
            _clientid = clientid;
            ScopeInfo = new RegistrationScope(_clientid);
            Description = description;
        }

    }


    public struct RegistrationScope
    {
        private string _scopeid;
        private string _scopename;

        public string ScopeId
        {
            get { return _scopeid; }
            private set { _scopeid = value; }
        }

        public string ScopeName
        {
            get { return _scopename; }
            private set { _scopename = value; }
        }


        public RegistrationScope(string id)
        {
            _scopename = id;
            _scopeid = "scope_" + id;

        }
    }


}
