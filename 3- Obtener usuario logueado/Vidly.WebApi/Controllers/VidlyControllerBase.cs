using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Controllers.Users.Entities;

namespace Vidly.WebApi.Controllers
{
    public class VidlyControllerBase : ControllerBase
    {
        internal static List<Session> _sessions = [];

        protected User GetUserLogged(string token)
        {
            var session = _sessions.FirstOrDefault(s => s.Token == token);

            if(session == null)
            {
                throw new Exception("Token expired");
            }

            return session.User;
        }
    }
}
