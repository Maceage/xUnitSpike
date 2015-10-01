using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;
using xUnitSpike.Data.Mapping;

namespace xUnitSpike.Tests
{
    public class UnitTestBase
    {
        protected Fixture Fixture { get; }

        public UnitTestBase()
        {
            AutoMapperConfiguration.Configure();

            Fixture = new Fixture();
            Fixture.Customize(new AutoFakeItEasyCustomization());
        }
    }
}
