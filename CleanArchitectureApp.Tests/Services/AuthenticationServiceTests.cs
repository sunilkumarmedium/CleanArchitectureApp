using CleanArchitectureApp.Application.DTOs.Authentication;
using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Application.Interfaces.Services;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Shared.Services;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureApp.Tests.Services
{
    public class AuthenticationServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IUserRepositoryAsync> mockUserRepositoryAsync;
        private readonly Mock<ILoginLogRepositoryAsync> _mockLoginLogRepository;
        private readonly Mock<ILoginLogTypeRepositoryAsync> _mockLoginLogTypeRepository;
        private readonly Mock<IUserTokenRepositoryAsync> _mockUserTokenRepository;
        private readonly Mock<IEmailTemplateRepositoryAsync> _mockEmailTemplateRepository;
        private readonly Mock<IEmailRecipientRepositoryAsync> _mockEmailRecipientRepository;

        private Mock<IOptions<JwtConfig>> mockOptions;
        private Mock<IPasswordService> mockPasswordService;

        public AuthenticationServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUserRepositoryAsync = this.mockRepository.Create<IUserRepositoryAsync>();
            this.mockOptions = this.mockRepository.Create<IOptions<JwtConfig>>();
            this.mockPasswordService = this.mockRepository.Create<IPasswordService>();
            this._mockLoginLogRepository = this.mockRepository.Create<ILoginLogRepositoryAsync>();
            this._mockLoginLogTypeRepository = this.mockRepository.Create<ILoginLogTypeRepositoryAsync>();
            this._mockUserTokenRepository= this.mockRepository.Create<IUserTokenRepositoryAsync>();
            this._mockEmailTemplateRepository= this.mockRepository.Create<IEmailTemplateRepositoryAsync>();
            this._mockEmailRecipientRepository= this.mockRepository.Create<IEmailRecipientRepositoryAsync>();
        }

        private AuthenticationService CreateService()
        {
            return new AuthenticationService(
                this.mockUserRepositoryAsync.Object,
                this.mockOptions.Object,
                this.mockPasswordService.Object, this._mockLoginLogRepository.Object, this._mockLoginLogTypeRepository.Object, this._mockUserTokenRepository.Object, this._mockEmailTemplateRepository.Object, this._mockEmailRecipientRepository.Object);
        }

        [Fact]
        public async Task AuthenticateAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            AuthenticationRequest request = null;
            string ipAddress = null;

            // Act
            var result = await service.AuthenticateAsync(
                request,
                ipAddress);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ForgotPassword_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            ForgotPasswordRequest model = null;

            // Act
            await service.ForgotPassword(
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ResetPassword_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            ResetPasswordRequest model = null;

            // Act
            var result = await service.ResetPassword(
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}