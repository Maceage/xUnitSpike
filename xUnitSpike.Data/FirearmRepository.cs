using xUnitSpike.Data.Entities;
using xUnitSpike.Data.Interfaces;

namespace xUnitSpike.Data
{
    public class FirearmRepository : IFirearmRepository
    {
        public Firearm GetByIdentifier(string identifier)
        {
            return new Firearm
            {
                Identifier = "FR0123456789",
                SerialNumber1 = "0123456789",
                SerialNumber2 = "9876543210"
            };
        }
    }
}
