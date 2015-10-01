using FluentAssertions;
using Microsoft.Practices.Unity;
using xUnitSpike.Domain;
using xUnitSpike.Services.Interfaces;
using xUnitSpike.Tests;
using Xunit;

namespace xUnitSpike.Services.IntegrationTests
{
    public class FirearmServiceTests : IntegrationTestBase
    {
        private readonly IFirearmService _firearmService;

        public FirearmServiceTests()
        {
            _firearmService = UnityContainer.Resolve<IFirearmService>();
        }

        [Fact]
        public void GetByIdentifier_WhenCalled_ReturnsCorrectFirearm()
        {
            // Arrange
            string identifier = "0123456789";

            // Act
            Firearm firearm = _firearmService.GetByIdentifier(identifier);

            // Assert
            firearm.Should().NotBeNull();
        }
    }
}
