using Should;
using Xunit;

namespace SoundsUp.Business.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange

            // Act
            var isValid = true;

            // Assert
            isValid.ShouldBeTrue();
        }
    }
}