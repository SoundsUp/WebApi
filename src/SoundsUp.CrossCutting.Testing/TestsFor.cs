using Moq;
using StructureMap.AutoMocking.Moq;

// ReSharper disable VirtualMemberCallInConstructor

namespace SoundsUp.CrossCutting.Testing
{
    public abstract class TestsFor<TEntity> where TEntity : class
    {
        protected TEntity Instance;
        protected MoqAutoMocker<TEntity> AutoMock;

        protected TestsFor()
        {
            AutoMock = new MoqAutoMocker<TEntity>();

            OverrideMocks();

            Instance = AutoMock.ClassUnderTest;
        }

        protected virtual void OverrideMocks()
        {
        }

        protected void Inject<TContract>(TContract with) where TContract : class
        {
            AutoMock.Container.Inject(with);
        }

        protected Mock<TContract> GetMockFor<TContract>() where TContract : class
        {
            return Mock.Get(AutoMock.Get<TContract>());
        }
    }
}