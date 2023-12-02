using Domain.Core.Models.Entities;

namespace Adapters.Inbound.RestAdapters.Users.VM
{
    public record CreateUserResponse
    {

        public string realm { get; set; }
        public string clientid { get; set; }
        public string sysusername { get; set; }
        public string syspassword { get; set; }
        public string email { get; set; }


        public CreateUserResponse(User user)
        {
            this.realm = user.realm;
            this.clientid = user.clientid;
            this.sysusername = user.sysusername;
            this.syspassword = user.syspassword;
            this.email = user.email;
        }

    }
}
