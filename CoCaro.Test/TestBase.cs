using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Test
{
    // ref: https://thetddguy.com/2017/01/19/moq-102-mockrepository/
    [TestFixture]
    public abstract class TestBase<T> where T : class
    {
        MockRepository mockRepository;

        [Test]
        public void Constructor_Always_PerformExpectedWork()
        {
            VerifyAllMocks();
        }

        [SetUp]
        public void SetUp()
        {
            CreateMockRepository();
            CreateMocks();
            ConfigureConstructorMocks();
            SystemUnderTest = CreateSystemUnderTest();
        }

        protected T SystemUnderTest { get; private set; }

        protected abstract void ConfigureConstructorMocks();

        protected Mock<TMock> CreateMock<TMock>() where TMock : class
        {
            return mockRepository.Create<TMock>();
        }

        protected abstract void CreateMocks();

        protected abstract T CreateSystemUnderTest();

        protected void VerifyAllMocks()
        {
            mockRepository.VerifyAll();
        }

        void CreateMockRepository()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }
    }
}
