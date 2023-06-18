using Application.DTOs;
using Application.Interfaces.LoginService;
using Application.Services.LoginService;
using Moq;
using NUnit.Framework;

namespace UnitTests.ServicesUnitTests
{
    [TestFixture]
    internal class LoginServiceUT
    {
        private Mock<ILoginServiceHelper>? _mockHelper;
        private LoginService? _loginService;

        [SetUp]
        public void SetUp()
        {
            _mockHelper = new Mock<ILoginServiceHelper>();
            _loginService = new LoginService(_mockHelper.Object);
        }

        [Test]
        public async Task UserLogin_WithValidPasswordAndEmail_ReturnsJTW()
        {
            // Arrange
            var dto = new UserLoginRequest()
            {
                Email = "testemail@test.pl",
                Password = "Testpassword123!"
            };

            _mockHelper.Setup(helper => helper.VerifyPassword(dto))
                .ReturnsAsync(true);

            _mockHelper.Setup(helper => helper.GenerateToken(dto))
                .ReturnsAsync("example token");

            // Act

            var verifyResult = await _loginService.VerifyRequest(dto);
            var resultToken = await _loginService.GenerateToken(dto);

            // Assert 
            Assert.IsTrue(verifyResult);
            Assert.IsNotEmpty(resultToken);
        }

        [Test]
        public async Task UserLogin_WithInvalidPassword_ReturnsFalse()
        {
            // Arrange
            var dto = new UserLoginRequest()
            {
                Email = "testemail2@test.pl",
                Password = "Testpassword124!"
            };

            _mockHelper.Setup(helper => helper.VerifyPassword(dto))
                .ReturnsAsync(false);

            _mockHelper.Setup(helper => helper.GenerateToken(dto))
                .ReturnsAsync(string.Empty);

            // Act

            var verifyResult = await _loginService.VerifyRequest(dto);
            var resultToken = await _loginService.GenerateToken(dto);

            // Assert 
            Assert.IsFalse(verifyResult);
            Assert.IsEmpty(resultToken);
        }

        [Test]
        public async Task UserLogin_WithInvalidEmail_ReturnsFalse()
        {
            // Arrange
            var dto = new UserLoginRequest()
            {
                Email = "testemail3@test.pl",
                Password = "Testpassword126!"
            };

            _mockHelper.Setup(helper => helper.VerifyPassword(dto))
                .ReturnsAsync(false);

            _mockHelper.Setup(helper => helper.GenerateToken(dto))
                .ReturnsAsync(string.Empty);

            // Act

            var verifyResult = await _loginService.VerifyRequest(dto);
            var resultToken = await _loginService.GenerateToken(dto);

            // Assert 
            Assert.IsFalse(verifyResult);
            Assert.IsEmpty(resultToken);
        }
    }
}
