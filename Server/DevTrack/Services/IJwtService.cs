namespace DevTrack.Services
{
    public interface IJwtService
    {
        string GenerateToken(int UserId);
    }
}
