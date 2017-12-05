namespace SoundsUp.Domain.Contracts
{
    public interface IAuthenticator
    {
        bool Verify(string password, string hash);

        string HashPassword(string password);
    }
}