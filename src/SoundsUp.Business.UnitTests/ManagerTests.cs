using Moq;
using SoundsUp.CrossCutting.Testing;
using SoundsUp.Domain.Contracts;
using System.Threading.Tasks;
using Xunit;

namespace SoundsUp.Business.UnitTests
{
    public class ManagerTests : TestsFor<Manager>
    {
        [Fact]
        public async Task Get_ValidatorSetToTrue_RepositoryIsCalled()
        {
            //Arrange
            GetMockFor<IValidator>().Setup(v => v.ValidateId(It.IsAny<int>())).Returns(true);

            var id = 1;

            // Act
            await Instance.Get(id);

            // Assert
            GetMockFor<IRepository>().Verify(r => r.Get(id), Times.Once);
        }
    }
}