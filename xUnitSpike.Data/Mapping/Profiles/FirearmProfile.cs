using AutoMapper;
using xUnitSpike.Data.Entities;
using xUnitSpike.Domain;

namespace xUnitSpike.Data.Mapping.Profiles
{
    public class FirearmProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<FirearmEntity, Firearm>().ReverseMap();
        }
    }
}