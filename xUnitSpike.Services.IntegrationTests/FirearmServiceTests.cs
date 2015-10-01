using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Practices.Unity;
using Ploeh.AutoFixture;
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
        public void GetAll_WhenCalled_ReturnsAllFirearms()
        {
            // Act
            IEnumerable<Firearm> firearms = _firearmService.GetAll();

            // Assert
            firearms.Should().NotBeNull();
        }

        [Fact]
        public void GetByIdentifier_WhenCalled_ReturnsCorrectFirearm()
        {
            // Arrange
            string identifier = "FR0123456789";

            // Act
            Firearm firearm = _firearmService.GetByIdentifier(identifier);

            // Assert
            firearm.Should().NotBeNull();
        }

        [Fact]
        public void Save_WithFirearm_SavesFirearmToDatabase()
        {
            // Arrange
            Firearm firearm = Fixture.Create<Firearm>();

            // Act
            Firearm savedFirearm = _firearmService.Save(firearm);

            // Assert
            savedFirearm.Identifier.Should().NotBeNullOrWhiteSpace();
            savedFirearm.Identifier.Should().Be(firearm.Identifier);

            Firearm createdFirearm = _firearmService.GetByIdentifier(savedFirearm.Identifier);
            createdFirearm.ShouldBeEquivalentTo(firearm);
        }

        [Fact]
        public void Delete_WithFirearm_DeletesFirearmFromDatabase()
        {
            // Arrange
            Firearm firearm = Fixture.Create<Firearm>();

            Firearm savedFirearm = _firearmService.Save(firearm);
            savedFirearm.Identifier.Should().NotBeNullOrWhiteSpace();

            // Act
            bool isDeleted = _firearmService.Delete(firearm);

            // Assert
            isDeleted.Should().BeTrue();
        }
    }
}
