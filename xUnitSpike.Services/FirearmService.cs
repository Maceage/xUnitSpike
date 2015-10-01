using System.Collections.Generic;
using AutoMapper;
using xUnitSpike.Data.Entities;
using xUnitSpike.Data.Interfaces;
using xUnitSpike.Services.Interfaces;

namespace xUnitSpike.Services
{
    public class FirearmService : IFirearmService
    {
        private readonly IFirearmRepository _firearmRepository;

        public FirearmService(IFirearmRepository firearmRepository)
        {
            _firearmRepository = firearmRepository;
        }

        public IEnumerable<Domain.Firearm> GetAll()
        {
            var firearms = _firearmRepository.GetAll();

            return Mapper.Map<IList<Domain.Firearm>>(firearms);
        }

        public Domain.Firearm GetByIdentifier(string identifier)
        {
            var firearm = _firearmRepository.GetByIdentifier(identifier);

            return Mapper.Map<Domain.Firearm>(firearm);
        }

        public string Save(Domain.Firearm firearm)
        {
            var dataFirearm = Mapper.Map<Firearm>(firearm);

            return _firearmRepository.Save(dataFirearm);
        }
    }
}