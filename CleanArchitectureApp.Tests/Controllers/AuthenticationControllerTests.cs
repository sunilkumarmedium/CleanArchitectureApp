using CleanArchitectureApp.Application.DTOs.Authentication;
using CleanArchitectureApp.Application.Interfaces.Services;
using CleanArchitectureApp.WebApi.Controllers;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureApp.Tests.Controllers
{
    public class AuthenticationControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IAuthenticationService> mockAuthenticationService;

        public AuthenticationControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAuthenticationService = this.mockRepository.Create<IAuthenticationService>();
        }

        private AuthenticationController CreateAuthenticationController()
        {
            return new AuthenticationController(
                this.mockAuthenticationService.Object);
        }

        [Fact]
        public async Task AuthenticateAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var authenticationController = this.CreateAuthenticationController();
            AuthenticationRequest request = null;

            // Act
            var result = await authenticationController.AuthenticateAsync(
                request);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}