using Microsoft.Practices.Unity;
using Ploeh.AutoFixture;
using xUnitSpike.Data.Mapping;
using xUnitSpike.Dependencies;

namespace xUnitSpike.Tests
{
    public class IntegrationTestBase
    {
        protected IUnityContainer UnityContainer { get; }

        protected Fixture Fixture { get; }

        public IntegrationTestBase()
        {
            UnityContainer = new UnityContainer();
            UnityConfig.Register(UnityContainer);

            AutoMapperConfiguration.Configure();

            Fixture = new Fixture();
        }
    }
}