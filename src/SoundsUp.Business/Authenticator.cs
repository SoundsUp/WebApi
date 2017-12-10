using Sodium;
using SoundsUp.Domain.Contracts;

namespace SoundsUp.Business
{
    public class Authenticator : IAuthenticator
    {
        //https://github.com/tabrath/libsodium-core
        public bool Verify(string password, string hash)
        {
            return PasswordHash.ArgonHashStringVerify(hash, password);
        }

        public string HashPassword(string password)
        {
            // hash and save a password
            return PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Moderate);
        }
    }
}