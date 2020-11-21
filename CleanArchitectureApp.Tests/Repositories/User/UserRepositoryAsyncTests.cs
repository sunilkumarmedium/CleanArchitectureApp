using CleanArchitectureApp.Infrastructure.Persistence.Repositories;
using Moq;
using NHibernate;
using Xunit;

namespace CleanArchitectureApp.Tests.Repositories.User
{
    public class UserRepositoryAsyncTests
    {
        private MockRepository mockRepository;

        private Mock<ISession> mockSession;

        public UserRepositoryAsyncTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockSession = this.mockRepository.Create<ISession>();
        }

        private UserRepositoryAsync CreateUserRepositoryAsync()
        {
            return new UserRepositoryAsync(
                this.mockSession.Object);
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var userRepositoryAsync = this.CreateUserRepositoryAsync();

            // Act

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}