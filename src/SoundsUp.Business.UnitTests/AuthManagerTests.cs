using Moq;
using Should;
using SoundsUp.CrossCutting.Testing;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace SoundsUp.Business.UnitTests
{
    public class AuthManagerTests : TestsFor<AuthManager>
    {
        #region Register Tests

        [Fact]
        public async Task Login_PasswordValid_ReturnsAccount()
        {
            //Arrange
            GetMockFor<IPasswordHash>().Setup(v => v.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            GetMockFor<IAuthRepository>().Setup(v => v.Get(It.IsAny<Expression<Func<Users, bool>>>())).Returns(Task.FromResult(new Users()));

            // Act
            var result = await Instance.Login(new LoginViewModel());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Login_PasswordInvalid_Returnsnull()
        {
            //Arrange
            GetMockFor<IPasswordHash>().Setup(v => v.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            GetMockFor<IAuthRepository>().Setup(v => v.Get(It.IsAny<Expression<Func<Users, bool>>>())).Returns(Task.FromResult(new Users()));

            // Act
            var result = await Instance.Login(new LoginViewModel());

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task Login_EmailNotFound_Returnsnull()
        {
            //Arrange
            GetMockFor<IPasswordHash>().Setup(v => v.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            GetMockFor<IAuthRepository>().Setup(v => v.Get(It.IsAny<Expression<Func<Users, bool>>>())).Returns(Task.FromResult(new Users()));

            // Act
            var result = await Instance.Login(new LoginViewModel());

            // Assert
            result.ShouldBeNull();
        }

        #endregion Register Tests

        #region Login Tests

        [Fact]
        public async Task Register_ValidModel_ReturnsAccount()
        {
            //Arrange
            GetMockFor<IAuthRepository>().Setup(v => v.Register(It.IsAny<Users>())).Returns(Task.FromResult(new Users()));

            // Act
            var result = await Instance.Register(new RegisterViewModel());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Register_InvalidModel_Returnsnull()
        {
            // Act
            var result = await Instance.Register(null);

            // Assert
            result.ShouldBeNull();
        }

        #endregion Login Tests
    }
}