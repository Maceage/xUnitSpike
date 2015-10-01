using Microsoft.Practices.Unity;
using xUnitSpike.Data;
using xUnitSpike.Data.Interfaces;
using xUnitSpike.Services;
using xUnitSpike.Services.Interfaces;

namespace xUnitSpike.Dependencies
{
    public static class UnityConfig
    {
        public static void Register(IUnityContainer unityContainer)
        {
            RegisterServices(unityContainer);
            RegisterData(unityContainer);
        }

        private static void RegisterServices(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IFirearmService, FirearmService>();
        }

        private static void RegisterData(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IFirearmRepository, FirearmRepository>();
        }
    }
}
