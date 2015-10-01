using AutoMapper;
using xUnitSpike.Data.Mapping.Profiles;

namespace xUnitSpike.Data.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.AddProfile<FirearmProfile>();
        }
    }
}