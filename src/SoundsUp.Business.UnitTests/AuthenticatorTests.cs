using Should;
using SoundsUp.CrossCutting.Testing;
using Xunit;

namespace SoundsUp.Business.UnitTests
{
    public class AuthenticatorTests : TestsFor<Authenticator>
    {
        [Fact]
        public void Verify_ValidPassword_ResultIsTrue()
        {
            //Arrange

            var password = "SecurePassword";
            var passwordHash = Instance.HashPassword(password);

            // Act
            var result = Instance.Verify(password, passwordHash);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void Verify_InvalidPassword_ResultIsFalse()
        {
            //Arrange

            var password = "SecurePassword";
            var passwordHash = Instance.HashPassword("NotSoSecure");

            // Act
            var result = Instance.Verify(password, passwordHash);

            // Assert
            result.ShouldBeFalse();
        }
    }
}