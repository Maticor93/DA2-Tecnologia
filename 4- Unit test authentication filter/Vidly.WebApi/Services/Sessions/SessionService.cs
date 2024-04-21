using Vidly.WebApi.Services.Sessions.Entities;

namespace Vidly.WebApi.Services.Sessions
{
    public sealed class SessionService : ISessionService
    {
        private static readonly List<Session> _sessions = new List<Session>();

        public User GetUserByToken(string token)
        {
            var session = _sessions.FirstOrDefault(s => s.Token == token);

            if (session == null)
                throw new Exception("Session not found");

            return session.User;
        }
    }
}
