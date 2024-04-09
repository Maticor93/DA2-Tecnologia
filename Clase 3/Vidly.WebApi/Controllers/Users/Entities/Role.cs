namespace Vidly.WebApi.Controllers.Users.Entities
{
    public sealed record class Role
    {
        public List<PermissionKey> Permissions { get; init; }

        public Role()
        {
            Permissions = new List<PermissionKey>();
        }

        public bool HasPermission(PermissionKey permission)
        {
            return Permissions.Contains(permission);
        }
    }
}
