using Vidly.WebApi.Services.Users;

namespace Vidly.WebApi.Services.Sessions
{
    public interface ISessionService
    {
        User GetUserByToken(string token);
    }
}
