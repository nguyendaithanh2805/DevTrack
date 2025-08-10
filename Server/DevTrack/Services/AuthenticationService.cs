using DevTrack.DTOs;
using DevTrack.Exceptions;
using DevTrack.Models;
using DevTrack.Repositories;

namespace DevTrack.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<TblUser> _userRepository;
        private readonly IJwtService _jwtService;

        public AuthenticationService(IRepository<TblUser> userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Login(string username, string password)
        {
            var user = (await _userRepository.FindWithExpressionAsync(u => u.Username == username)).FirstOrDefault();

            if (user is null)
                throw new NotFoundException("User not found");

            if (user.Password != password)
                throw new UnauthorizedAccessException("Invalid password.");

            return _jwtService.GenerateToken(user.Id);
        }
    }
}
