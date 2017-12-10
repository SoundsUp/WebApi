using Should;
using SoundsUp.CrossCutting.Testing;
using Xunit;

namespace SoundsUp.Business.UnitTests
{
    public class PasswordHashTests : TestsFor<PasswordHash>
    {
        [Fact]
        public void Verify_ValidPassword_ResultIsTrue()
        {
            //Arrange
            const string password = "SecurePassword";
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
            const string password = "SecurePassword";
            var passwordHash = Instance.HashPassword("NotSoSecure");

            // Act
            var result = Instance.Verify(password, passwordHash);

            // Assert
            result.ShouldBeFalse();
        }
    }
}