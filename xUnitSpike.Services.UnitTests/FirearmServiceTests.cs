using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Ploeh.AutoFixture;
using xUnitSpike.Data.Entities;
using xUnitSpike.Data.Interfaces;
using xUnitSpike.Domain;
using xUnitSpike.Tests;
using Xunit;

namespace xUnitSpike.Services.UnitTests
{
    public class FirearmServiceTests : UnitTestBase
    {
        private readonly IFirearmRepository _firearmRepository;
        private readonly FirearmService _firearmService;

        public FirearmServiceTests()
        {
            _firearmRepository = Fixture.Freeze<IFirearmRepository>();

            _firearmService = Fixture.Create<FirearmService>();
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsAllFirearms()
        {
            // Arrange
            IQueryable<FirearmEntity> firearms = Fixture.CreateMany<FirearmEntity>().AsQueryable();
            var expected = Mapper.Map<IEnumerable<Firearm>>(firearms);

            A.CallTo(() => _firearmRepository.GetAll()).Returns(firearms);

            // Act
            var actual = _firearmService.GetAll();

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);

            A.CallTo(() => _firearmRepository.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void Get_WithFirearmIdentifier_ReturnsFirearmWithIdentifier()
        {
            // Arrange
            string identifier = Fixture.Create<string>();

            FirearmEntity firearmEntity = Fixture.Create<FirearmEntity>();
            var expected = Mapper.Map<Firearm>(firearmEntity);

            A.CallTo(() => _firearmRepository.GetByIdentifier(A<string>.That.IsEqualTo(identifier))).ReturnsLazily(f => firearmEntity);

            // Act
            var actual = _firearmService.GetByIdentifier(identifier);

            // Assert
            actual.ShouldBeEquivalentTo(expected, o => o.IncludingProperties());

            A.CallTo(() => _firearmRepository.GetByIdentifier(A<string>.That.IsEqualTo(identifier))).MustHaveHappened();
        }

        [Fact]
        public void Save_WithFirearm_SavesToRepository()
        {
            // Arrange
            FirearmEntity firearmEntity = Fixture.Create<FirearmEntity>();
            Firearm expected = Mapper.Map<Firearm>(firearmEntity);

            A.CallTo(() => _firearmRepository.Save(A<FirearmEntity>._)).Returns(firearmEntity);

            // Act
            Firearm actual = _firearmService.Save(expected);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public void Delete_WithFirearm_DeletesFromRepository()
        {
            // Arrange
            Firearm firearm = Fixture.Create<Firearm>();

            A.CallTo(() => _firearmRepository.Delete(A<FirearmEntity>._)).Returns(true);

            // Act
            bool actual = _firearmService.Delete(firearm);

            // Assert
            actual.Should().BeTrue();
        }
    }
}