using System;
using FluentAssertions;
using Microsoft.Practices.Unity;
using xUnitSpike.Data;
using xUnitSpike.Data.Interfaces;
using xUnitSpike.Services;
using xUnitSpike.Services.Interfaces;
using xUnitSpike.Tests;
using Xunit;

namespace xUnitSpike.Dependencies.UnitTests
{
    public class UnityConfigTests : UnitTestBase
    {
        private readonly UnityContainer _unityContainer = new UnityContainer();

        public UnityConfigTests()
        {
            UnityConfig.Register(_unityContainer);
        }

        [Theory]
        [InlineData(typeof(IFirearmService), typeof(FirearmService))]
        public void Resolve_WithUnityConfig_HasServiceTypesRegistered(Type interfaceType, Type concreteType)
        {
            // Act
            object resolvedType = _unityContainer.Resolve(interfaceType);

            // Assert
            resolvedType.Should().BeOfType(concreteType);
        }

        [Theory]
        [InlineData(typeof(IFirearmRepository), typeof(FirearmRepository))]
        public void Resolve_WithUnityConfig_HasDataTypesRegistered(Type interfaceType, Type concreteType)
        {
            // Act
            object resolvedType = _unityContainer.Resolve(interfaceType);

            // Assert
            resolvedType.Should().BeOfType(concreteType);
        }
    }
}
