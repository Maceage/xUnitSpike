using Microsoft.Practices.Unity;
using xUnitSpike.Data.Mapping;
using xUnitSpike.Dependencies;
using xUnitSpike.Domain;
using xUnitSpike.Services.Interfaces;

namespace xUnitSpike
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UnityContainer unityContainer = new UnityContainer();
            UnityConfig.Register(unityContainer);

            AutoMapperConfiguration.Configure();

            IFirearmService firearmService = unityContainer.Resolve<IFirearmService>();
            Firearm firearm = firearmService.GetByIdentifier("FR0123456789");
        }
    }
}