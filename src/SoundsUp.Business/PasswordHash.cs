using Sodium;
using SoundsUp.Domain.Contracts;

namespace SoundsUp.Business
{
    public class PasswordHash : IPasswordHash
    {
        //https://github.com/tabrath/libsodium-core
        public bool Verify(string password, string hash)
        {
            return Sodium.PasswordHash.ArgonHashStringVerify(hash, password);
        }

        public string HashPassword(string password)
        {
            // hash and save a password
            return Sodium.PasswordHash.ArgonHashString(password, Sodium.PasswordHash.StrengthArgon.Moderate);
        }
    }
}