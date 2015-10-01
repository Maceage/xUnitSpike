using System;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture;
using xUnitSpike.Data.Entities;
using xUnitSpike.Tests;
using Xunit;

namespace xUnitSpike.Data.IntegrationTests
{
    public class FirearmRepositoryTests : IntegrationTestBase
    {
        private readonly FirearmRepository _firearmRepository;

        public FirearmRepositoryTests()
        {
            _firearmRepository = new FirearmRepository();
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsAllFirearms()
        {
            // Act
            IQueryable<FirearmEntity> firearms = _firearmRepository.GetAll();

            // Assert
            firearms.ToList().Should().NotBeNull();
        }

        [Theory]
        [InlineData("FR0123456789")]
        [InlineData("FR9876543210")]
        [InlineData("FR1111111111")]
        [InlineData("FR2222222222")]
        [InlineData("FR3333333333")]
        [InlineData("FR4444444444")]
        [InlineData("FR5555555555")]
        [InlineData("FR6666666666")]
        [InlineData("FR7777777777")]
        [InlineData("FR8888888888")]
        [InlineData("FR9999999999")]
        public void GetByIdentifier_WithIdentifier_ReturnsFirearmWithIdentifier(string identifier)
        {
            // Act
            var firearm = _firearmRepository.GetByIdentifier(identifier);

            // Assert
            firearm.Should().NotBeNull();
            firearm.Identifier.Should().Be(identifier);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void GetByIdentifier_WithInvalidFirearmIdentifier_ThrowsException(string identifier)
        {
            // Arrange
            Action action = () => _firearmRepository.GetByIdentifier(identifier);

            // Act/Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Save_WithFirearm_AddsFirearmToDatabase()
        {
            // Arrange
            FirearmEntity firearmEntity = Fixture.Create<FirearmEntity>();

            // Act
            var savedFirearm = _firearmRepository.Save(firearmEntity);

            // Assert
            savedFirearm.Should().NotBeNull();
        }

        [Fact]
        public void Save_WithNullFirearm_ThrowsException()
        {
            // Arrange
            Action action = () => _firearmRepository.Save(null);

            // Act/Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Delete_WithExistingFirearm_DeletesFirearmFromDatabase()
        {
            // Arrange
            FirearmEntity firearmEntity = Fixture.Create<FirearmEntity>();

            var savedFirearm = _firearmRepository.Save(firearmEntity);

            // Act
            bool isDeleted = _firearmRepository.Delete(savedFirearm);

            // Assert
            isDeleted.Should().BeTrue();
        }

        [Fact]
        public void Delete_WithNonExistingFirearm_ThrowsException()
        {
            // Arrange
            FirearmEntity firearmEntity = Fixture.Create<FirearmEntity>();

            bool isDeleted = false;

            Action action = () => isDeleted = _firearmRepository.Delete(firearmEntity);

            // Act
            action.ShouldThrow<Exception>();

            // Assert
            isDeleted.Should().BeFalse();
        }

        [Fact]
        public void Delete_WithNullFirearm_ThrowsException()
        {
            // Arrange
            Action action = () => _firearmRepository.Delete(null);

            // Act/Assert
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
