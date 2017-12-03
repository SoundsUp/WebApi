namespace SoundsUp.Business
{
    public interface IAuthenticator
    {
        bool Verify(string password, string passwordHash);

        string HashPassword(string password);
    }
}