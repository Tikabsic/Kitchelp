using Application.DTOs;
using Application.Interfaces.RegisterService;
using Application.Services.RegisterService;
using Moq;
using NUnit.Framework;

namespace UnitTests.ServicesUnitTests
{
    [TestFixture]
    internal class RegisterServiceUT
    {
        private Mock<IRegisterServiceHelper>? _mockRegisterServiceHelper;
        private RegisterService? _registerService;

        [SetUp]
        public void SetUp()
        {
            _mockRegisterServiceHelper = new Mock<IRegisterServiceHelper>();
            _registerService = new RegisterService(_mockRegisterServiceHelper.Object);
        }

        [Test]
        public async Task RegisterOwner_WithValidRequest_ReturnsTrue()
        {
            // Arrange
            var dto = new RegisterRequestDTO()
            {
                Email = "dto@dto.dto",
                Password = "Dto123Dto!",
                ConfirmPassword = "Dto123Dto!",
                FirstName = "Jakub",
                LastName = "Makowski",
                DateOfBirth = "11.02.1997"
            };

            _mockRegisterServiceHelper
                .Setup(helper => helper.ValidateRequest(dto))
                .ReturnsAsync(true); // Simulate a successful validation

            _mockRegisterServiceHelper
                .Setup(helper => helper.RegisterOwner(dto))
                .ReturnsAsync(true); // Simulate a successful owner registration

            // Act
            var result = await _registerService.RegisterOwner(dto);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task RegisterOwner_WithInvalidRequest_DifferentPasswords_ReturnsFalse()
        {
            // Arrange
            var dto = new RegisterRequestDTO()
            {
                Email = "dto@dto.dto",
                Password = "Dto123Dto!",
                ConfirmPassword = "Dto123DTO",
                FirstName = "Jakub",
                LastName = "Makowski",
                DateOfBirth = "11.02.1997"
            };

            _mockRegisterServiceHelper
                .Setup(h => h.ValidateRequest(dto))
                .ReturnsAsync(false);

            _mockRegisterServiceHelper
                .Setup(helper => helper.RegisterOwner(dto))
                .ReturnsAsync(false);

            // Act
            var result = await _registerService.RegisterOwner(dto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task RegisterOwner_WithInvalidRequest_WrongEmail_ReturnsFalse()
        {
            // Arrange
            var dto = new RegisterRequestDTO()
            {
                Email = "dtodto.dto",
                Password = "Dto123Dto!",
                ConfirmPassword = "Dto123DTO",
                FirstName = "Jakub",
                LastName = "Makowski",
                DateOfBirth = "11.02.1997"
            };

            _mockRegisterServiceHelper
                .Setup(h => h.ValidateRequest(dto))
                .ReturnsAsync(false);

            // Act
            var result = await _registerService.RegisterOwner(dto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task RegisterOwner_WithInvalidRequest_NoFirstName_ReturnsFalse()
        {
            // Arrange
            var dto = new RegisterRequestDTO()
            {
                Email = "dto@dto.dto",
                Password = "Dto123Dto!",
                ConfirmPassword = "Dto123DTO",
                FirstName = null,
                LastName = "Makowski",
                DateOfBirth = "11.02.1997"
            };

            _mockRegisterServiceHelper
                .Setup(h => h.ValidateRequest(dto))
                .ReturnsAsync(false);

            _mockRegisterServiceHelper
                .Setup(helper => helper.RegisterOwner(dto))
                .ReturnsAsync(false);

            // Act
            var result = await _registerService.RegisterOwner(dto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task RegisterOwner_WithInvalidRequest_NoLastName_ReturnsFalse()
        {
            // Arrange
            var dto = new RegisterRequestDTO()
            {
                Email = "dto@dto.dto",
                Password = "Dto123Dto!",
                ConfirmPassword = "Dto123DTO",
                FirstName = "Jakub",
                LastName = null,
                DateOfBirth = "11.02.1997"
            };

            _mockRegisterServiceHelper
                .Setup(h => h.ValidateRequest(dto))
                .ReturnsAsync(false);

            _mockRegisterServiceHelper
                .Setup(helper => helper.RegisterOwner(dto))
                .ReturnsAsync(false);

            // Act
            var result = await _registerService.RegisterOwner(dto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task RegisterOwner_WithInvalidRequest_NoDateOfBirth_ReturnsFalse()
        {
            // Arrange
            var dto = new RegisterRequestDTO()
            {
                Email = "dto@dto.dto",
                Password = "Dto123Dto!",
                ConfirmPassword = "Dto123DTO",
                FirstName = "Jakub",
                LastName = "Makowski",
                DateOfBirth = null
            };

            _mockRegisterServiceHelper
                .Setup(h => h.ValidateRequest(dto))
                .ReturnsAsync(false);

            _mockRegisterServiceHelper
                .Setup(helper => helper.RegisterOwner(dto))
                .ReturnsAsync(false);

            // Act
            var result = await _registerService.RegisterOwner(dto);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
