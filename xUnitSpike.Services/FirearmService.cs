using System;
using System.Collections.Generic;
using AutoMapper;
using xUnitSpike.Data.Entities;
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
            if (string.IsNullOrWhiteSpace(identifier))
            {
                throw new ArgumentNullException(nameof(identifier));
            }

            var firearm = _firearmRepository.GetByIdentifier(identifier);

            return Mapper.Map<Firearm>(firearm);
        }

        public Firearm Save(Firearm firearm)
        {
            if (firearm == null)
            {
                throw new ArgumentNullException(nameof(firearm));
            }

            var firearmData = Mapper.Map<FirearmEntity>(firearm);
            var savedFirearm = _firearmRepository.Save(firearmData);

            return Mapper.Map<Firearm>(savedFirearm);
        }

        public bool Delete(Firearm firearm)
        {
            if (firearm == null)
            {
                throw new ArgumentNullException(nameof(firearm));
            }

            var firearmData = Mapper.Map<FirearmEntity>(firearm);

            return _firearmRepository.Delete(firearmData);
        }
    }
}