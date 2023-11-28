namespace Adapters.Inbound.RestAdapters.Users.VM
{
    public record ListUsersResponse
    {

        public List<UserResponse> Users { get; set; }
    }
}
