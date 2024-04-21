namespace Vidly.WebApi.Services.Sessions.Entities
{
    public sealed record class User
    {
        public string Id { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public Role Role { get; init; }
    }
}
