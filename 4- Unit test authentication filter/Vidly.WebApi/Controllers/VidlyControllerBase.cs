using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Services.Sessions.Entities;

namespace Vidly.WebApi.Controllers
{
    public class VidlyControllerBase : ControllerBase
    {
        protected User GetUserLogged()
        {
            var userLogged = HttpContext.Items[Items.UserLogged];

            var userLoggedMapped = (User)userLogged;

            return userLoggedMapped;
        }
    }
}
