using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Services.Users;

namespace Vidly.WebApi.Controllers
{
    public class VidlyControllerBase
        : ControllerBase
    {
        protected User GetUserLogged()
        {
            var userLogged = HttpContext.Items[Item.UserLogged];

            var userLoggedMapped = (User)userLogged;

            return userLoggedMapped;
        }
    }
}
