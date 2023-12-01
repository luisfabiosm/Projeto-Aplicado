using Domain.Core.Base;
using Domain.Core.Enums;
using Domain.Core.Models.Entities;
using Newtonsoft.Json;

namespace Domain.UseCases.GetUserAuthorization
{
    public record TransactionGetAuthorization : BaseTransaction
    {
        public TransactionGetAuthorization()
        {

        }

        public TransactionGetAuthorization(DateTime date, int code) : base(date, code)
        {
            TransactionCode = 101;
            TransactionDate = date;
        }

        private string _userrequest;
        private string _passwordrequest;
        private string _clientid;
        private string _realm;
        private AuthCredentials _credentials { get; set; }

        public string UserRequest   // property
        {
            get { return _userrequest; }
            set
            {

                _userrequest = value;
                TransactionLog.trandetailinfo += $" UserRequest:{_userrequest}";
            }
        }

        public string Realm   // property
        {
            get { return _realm; }
            set
            {

                _realm = value;
                TransactionLog.trandetailinfo += $" Realm:{_realm}";
            }
        }

        public string ClientId   // property
        {
            get { return _clientid; }
            set
            {

                _clientid = value;
                TransactionLog.trandetailinfo += $" ClientId:{_clientid}";
            }
        }

        public string PassworRequest   // property
        {
            get { return _passwordrequest; }
            set
            {

                _passwordrequest = value;
                TransactionLog.trandetailinfo += $" PassworRequest:{_passwordrequest.Substring(0, 4)} + {_passwordrequest.PadLeft(4)} ";
            }
        }

    }
}
