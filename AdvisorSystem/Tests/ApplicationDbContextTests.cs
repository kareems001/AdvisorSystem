using Microsoft.EntityFrameworkCore;
using AdvisorSystem.Data;
using AdvisorSystem.Models;
using Xunit;

namespace AdvisorSystem.Tests
{
    public class ApplicationDbContextTests
    {
        [Fact]
        public void Can_Add_Advisor_To_Database()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new ApplicationDbContext(options);
            var advisor = new Advisor
            {
                FullName = "Test Advisor",
                SIN = "123456789",
                Address = "123 Test Street",
                PhoneNumber = "5555555555",
                HealthStatus = "Green"
            };

            // Act
            context.Advisors.Add(advisor);
            context.SaveChanges();

            // Assert
            var savedAdvisor = context.Advisors.Find(advisor.Id);
            Assert.NotNull(savedAdvisor);
            Assert.Equal("Test Advisor", savedAdvisor.FullName);
        }

        [Fact]
        public void Can_Retrieve_Advisor_From_Database()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new ApplicationDbContext(options);
            var advisor = new Advisor
            {
                FullName = "Retrieve Test",
                SIN = "987654321",
                Address = "456 Test Avenue",
                PhoneNumber = "5559876543",
                HealthStatus = "Yellow"
            };
            context.Advisors.Add(advisor);
            context.SaveChanges();

            // Act
            var retrievedAdvisor = context.Advisors.Find(advisor.Id);

            // Assert
            Assert.NotNull(retrievedAdvisor);
            Assert.Equal("Retrieve Test", retrievedAdvisor.FullName);
        }
    }
}
