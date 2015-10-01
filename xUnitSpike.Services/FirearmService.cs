using System.Collections.Generic;
using AutoMapper;
using xUnitSpike.Data.Interfaces;
using xUnitSpike.Domain;
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

        public IEnumerable<Firearm> GetAll()
        {
            var firearms = _firearmRepository.GetAll();

            return Mapper.Map<IList<Firearm>>(firearms);
        }

        public Firearm GetByIdentifier(string identifier)
        {
            var firearm = _firearmRepository.GetByIdentifier(identifier);

            return Mapper.Map<Firearm>(firearm);
        }
    }
}