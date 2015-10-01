using System.Collections.Generic;
using System.Linq;
using xUnitSpike.Data.Entities;
using xUnitSpike.Data.Interfaces;

namespace xUnitSpike.Data
{
    public class FirearmRepository : IFirearmRepository
    {
        private readonly IList<FirearmEntity> _firearms = new List<FirearmEntity>
        {
            new FirearmEntity { Identifier = "FR0123456789", SerialNumber1 = "0123456789", SerialNumber2 = "0123456789" },
            new FirearmEntity { Identifier = "FR9876543210", SerialNumber1 = "9876543210", SerialNumber2 = "9876543210" },
            new FirearmEntity { Identifier = "FR1111111111", SerialNumber1 = "1111111111", SerialNumber2 = "1111111111" },
            new FirearmEntity { Identifier = "FR2222222222", SerialNumber1 = "2222222222", SerialNumber2 = "2222222222" },
            new FirearmEntity { Identifier = "FR3333333333", SerialNumber1 = "3333333333", SerialNumber2 = "3333333333" },
            new FirearmEntity { Identifier = "FR4444444444", SerialNumber1 = "4444444444", SerialNumber2 = "4444444444" },
            new FirearmEntity { Identifier = "FR5555555555", SerialNumber1 = "5555555555", SerialNumber2 = "5555555555" },
            new FirearmEntity { Identifier = "FR6666666666", SerialNumber1 = "6666666666", SerialNumber2 = "6666666666" },
            new FirearmEntity { Identifier = "FR7777777777", SerialNumber1 = "7777777777", SerialNumber2 = "7777777777" },
            new FirearmEntity { Identifier = "FR8888888888", SerialNumber1 = "8888888888", SerialNumber2 = "8888888888" },
            new FirearmEntity { Identifier = "FR9999999999", SerialNumber1 = "9999999999", SerialNumber2 = "9999999999" }
        };

        public IQueryable<FirearmEntity> GetAll()
        {
            return _firearms.AsQueryable();
        }

        public FirearmEntity GetByIdentifier(string identifier)
        {
            return _firearms.Single(f => f.Identifier == identifier);
        }

        public string Save(FirearmEntity firearmEntity)
        {
            _firearms.Add(firearmEntity);

            return firearmEntity.Identifier;
        }

        public bool Delete(FirearmEntity firearmEntity)
        {
            var firearm = _firearms.Single(f => f.Identifier == firearmEntity.Identifier);

            _firearms.Remove(firearm);

            return true;
        }
    }
}
