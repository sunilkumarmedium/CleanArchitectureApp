using CleanArchitectureApp.Infrastructure.Shared.Services;
using Moq;
using Xunit;

namespace CleanArchitectureApp.Tests.Services
{
    public class PasswordServiceTests
    {
        private MockRepository mockRepository;

        public PasswordServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private PasswordService CreateService()
        {
            return new PasswordService();
        }

        [Fact]
        public void Base64Decode_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string password = null;

            // Act
            var result = service.Base64Decode(
                password);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void IsBase64String_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string s = null;

            // Act
            var result = service.IsBase64String(
                s);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void CreatePasswordHash_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string password = null;
            string passwordHash = null;
            string passwordSalt = null;

            // Act
            service.CreatePasswordHash(
                password,
                out passwordHash,
                out passwordSalt);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void VerifyPasswordHash_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string password = null;
            byte[] storedHash = null;
            byte[] storedSalt = null;

            // Act
            var result = service.VerifyPasswordHash(
                password,
                storedHash,
                storedSalt);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}