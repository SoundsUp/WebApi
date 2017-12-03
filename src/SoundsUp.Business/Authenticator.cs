namespace SoundsUp.Business
{
    public class Authenticator : IAuthenticator
    {
        //https://github.com/BcryptNet/bcrypt.net
        public bool Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        public string HashPassword(string password)
        {
            // hash and save a password
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}