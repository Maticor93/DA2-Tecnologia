using Vidly.WebApi.Services.Sessions.Entities;

namespace Vidly.WebApi.Services.Sessions
{
    public interface ISessionService
    {
        User GetUserByToken(string token);
    }
}
