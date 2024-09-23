using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Vidly.WebApi.Services.Sessions.Entities;

namespace Vidly.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuthorizationFilterAttribute(string? permission = null) 
    : Attribute,
    IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.Result != null)
            {
                return;
            }

            var userLogged = context.HttpContext.Items[Items.UserLogged];

            var userIsNotIdentified = userLogged == null;
            if(userIsNotIdentified)
            {
                context.Result = new ObjectResult(new
                {
                    InnerCode = "UnAuthorized",
                    Message = $"Not authenticated"
                });
                return;
            }
            var userLoggedMapped = (User)userLogged;

            var permission = BuildPermission(context);

            var hasNotPermission = !userLoggedMapped.Role.HasPermission(permission);

            if (hasNotPermission)
            {
                context.Result = new ObjectResult(new
                {
                    InnerCode = "Forbidden",
                    Message = $"Missing permission {permission}"
                })
                {
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
            }
        }

        private string BuildPermission(AuthorizationFilterContext context)
        {
            return permission ?? $"{context.RouteData.Values["action"].ToString().ToLower()}-{context.RouteData.Values["controller"].ToString().ToLower()}";
        }
    }
}
