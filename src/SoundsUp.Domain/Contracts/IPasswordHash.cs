namespace SoundsUp.Domain.Contracts
{
    public interface IPasswordHash
    {
        bool Verify(string password, string hash);

        string HashPassword(string password);
    }
}