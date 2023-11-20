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
        private string _secretrequest;
        private AuthCredentials _credentials { get; set; }

        public string UserRequest   // property
        {
            get { return _userrequest; }
            set
            {

                _userrequest = value;
                TransactionLog.TranDetailInfo += $" UserRequest:{_userrequest}";
            }
        }

        public string SecretRequest   // property
        {
            get { return _secretrequest; }
            set
            {

                _secretrequest = value;
                TransactionLog.TranDetailInfo += $" SecretRequest:{_secretrequest.Substring(0, 4)} + {_secretrequest.PadLeft(4)} ";
            }
        }

        public AuthCredentials Credentials   // property
        {
            get { return _credentials; }
            set
            {

                _credentials = value;
                TransactionLog.TranDetailInfo += $" AuthCredentials:{JsonConvert.SerializeObject(_credentials)} ";
            }
        }
    }
}
