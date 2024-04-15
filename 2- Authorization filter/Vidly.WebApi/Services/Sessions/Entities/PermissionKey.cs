namespace Vidly.WebApi.Services.Sessions.Entities
{
    public sealed record class PermissionKey
    {
        public static readonly PermissionKey CreateMovie = new("create-movie");

        private readonly string Value;

        public PermissionKey(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
