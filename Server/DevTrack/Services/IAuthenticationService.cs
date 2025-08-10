using DevTrack.DTOs;

namespace DevTrack.Services
{
    public interface IAuthenticationService
    {
        public Task<string> Login(string username, string password);
    }
}
