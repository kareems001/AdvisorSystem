using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisorSystem.Models;
using AdvisorSystem.Services;
using Xunit;

namespace YourNamespace.Tests
{
    public class AdvisorServiceTests
    {
        private readonly Mock<IAdvisorService> _mockAdvisorService;

        public AdvisorServiceTests()
        {
            _mockAdvisorService = new Mock<IAdvisorService>();
        }

        [Fact]
        public async Task Can_Create_Advisor()
        {
            // Arrange
            var newAdvisor = new Advisor
            {
                FullName = "John Doe",
                SIN = "123456789",
                Address = "123 Main St",
                PhoneNumber = "5555555555",
                HealthStatus = "Green"
            };

            _mockAdvisorService.Setup(service => service.CreateAdvisorAsync(newAdvisor))
                .ReturnsAsync(newAdvisor);

            // Act
            var result = await _mockAdvisorService.Object.CreateAdvisorAsync(newAdvisor);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John Doe", result.FullName);
            Assert.Equal("123456789", result.SIN);
        }

        [Fact]
        public async Task Can_Get_Advisor_By_Id()
        {
            // Arrange
            var advisor = new Advisor
            {
                Id = 1,
                FullName = "Jane Smith",
                SIN = "987654321",
                Address = "456 Elm St",
                PhoneNumber = "5555551234",
                HealthStatus = "Yellow"
            };

            _mockAdvisorService.Setup(service => service.GetAdvisorByIdAsync(1))
                .ReturnsAsync(advisor);

            // Act
            var result = await _mockAdvisorService.Object.GetAdvisorByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Jane Smith", result.FullName);
        }

        [Fact]
        public async Task Can_Get_All_Advisors()
        {
            // Arrange
            var advisors = new List<Advisor>
            {
                new Advisor { Id = 1, FullName = "Advisor 1", SIN = "111111111" },
                new Advisor { Id = 2, FullName = "Advisor 2", SIN = "222222222" }
            };

            _mockAdvisorService.Setup(service => service.GetAllAdvisorsAsync())
                .ReturnsAsync(advisors);

            // Act
            var result = await _mockAdvisorService.Object.GetAllAdvisorsAsync();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, a => a.FullName == "Advisor 1");
        }

        [Fact]
        public async Task Can_Update_Advisor()
        {
            // Arrange
            var advisor = new Advisor
            {
                Id = 1,
                FullName = "Updated Name",
                SIN = "333333333",
                Address = "789 Oak St",
                PhoneNumber = "5555556789",
                HealthStatus = "Red"
            };

            _mockAdvisorService.Setup(service => service.UpdateAdvisorAsync(advisor))
                .ReturnsAsync(advisor);

            // Act
            var result = await _mockAdvisorService.Object.UpdateAdvisorAsync(advisor);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Name", result.FullName);
        }

        [Fact]
        public async Task Can_Delete_Advisor()
        {
            // Arrange
            const int advisorId = 1;

            _mockAdvisorService.Setup(service => service.DeleteAdvisorAsync(advisorId))
                .ReturnsAsync(true);

            // Act
            var result = await _mockAdvisorService.Object.DeleteAdvisorAsync(advisorId);

            // Assert
            Assert.True(result);
        }
    }
}
