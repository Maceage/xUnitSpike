using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Ploeh.AutoFixture;
using xUnitSpike.Data.Entities;
using xUnitSpike.Data.Interfaces;
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
            IQueryable<Firearm> firearms = Fixture.CreateMany<Firearm>().AsQueryable();
            var expected = Mapper.Map<IEnumerable<Domain.Firearm>>(firearms);

            A.CallTo(() => _firearmRepository.GetAll()).Returns(firearms);

            // Act
            var actual = _firearmService.GetAll();

            // Assert
            actual.ShouldAllBeEquivalentTo(expected);

            A.CallTo(() => _firearmRepository.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void Get_WithFirearmIdentifier_CallsRepository()
        {
            // Arrange
            string identifier = Fixture.Create<string>();

            Firearm firearm = Fixture.Create<Firearm>();
            var expected = Mapper.Map<Domain.Firearm>(firearm);

            A.CallTo(() => _firearmRepository.GetByIdentifier(A<string>.That.IsEqualTo(identifier))).ReturnsLazily(f => firearm);

            // Act
            var actual = _firearmService.GetByIdentifier(identifier);

            // Assert
            actual.ShouldBeEquivalentTo(expected, o => o.IncludingProperties());

            A.CallTo(() => _firearmRepository.GetByIdentifier(A<string>.That.IsEqualTo(identifier))).MustHaveHappened();
        }
    }
}