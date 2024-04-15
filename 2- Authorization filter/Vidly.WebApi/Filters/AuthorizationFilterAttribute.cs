using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Vidly.WebApi.Services.Sessions.Entities;

namespace Vidly.WebApi.Filters
{
    public sealed class AuthorizationFilterAttribute : AuthenticationFilterAttribute
    {
        private readonly string _permission;

        public AuthorizationFilterAttribute(string permission)
        {
            _permission = permission;
        }

        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            base.OnAuthorization(context);

            var userLogged = context.HttpContext.Items[Items.UserLogged];

            var userLoggedMapped = (User)userLogged;

            var permission = BuildPermission(context);

            var hasNotPermission = !userLoggedMapped.Role.HasPermission(permission);

            if (hasNotPermission)
            {
                context.Result = new ObjectResult(new
                {
                    InnerCode = "Forbidden",
                    Message = $"Missing permission {_permission}"
                })
                {
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
            }
        }

        private PermissionKey BuildPermission(AuthorizationFilterContext context)
        {
            return new PermissionKey(_permission);
        }
    }
}
