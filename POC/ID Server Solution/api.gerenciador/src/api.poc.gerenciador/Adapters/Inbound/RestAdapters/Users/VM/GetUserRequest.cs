namespace Adapters.Inbound.RestAdapters.Users.VM
{
    public record GetUserRequest
    {
        public string Realm { get; set; }

        public string Username { get; internal set; }
    }
}
