using Domain.Core.Base;

namespace Domain.UseCases.Users.GetUser
{
    public record TransactionGetUser : BaseTransaction
    {

        public string User { get; internal set; }
    }
}
