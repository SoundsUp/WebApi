using Moq;
using SoundsUp.CrossCutting.Testing;
using SoundsUp.Domain.Contracts;
using System.Threading.Tasks;
using Xunit;

namespace SoundsUp.Business.UnitTests
{
    public class UserManagerTests : TestsFor<UserManager>
    {
        [Fact]
        public async Task Get_ValidatorSetToTrue_RepositoryIsCalled()
        {
            //Arrange
            GetMockFor<IValidator>().Setup(v => v.ValidateId(It.IsAny<int>())).Returns(true);

            const int id = 1;

            // Act
            await Instance.Get(id);

            // Assert
            GetMockFor<IUserRepository>().Verify(r => r.Get(id), Times.Once);
        }
    }
}