using AutoMapper;

namespace xUnitSpike.Data.Mapping.Profiles
{
    public class FirearmProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Entities.Firearm, Domain.Firearm>();
        }
    }
}