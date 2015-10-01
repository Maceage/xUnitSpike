using xUnitSpike.Data.Entities;

namespace xUnitSpike.Data.Interfaces
{
    public interface IFirearmRepository
    {
        Firearm GetByIdentifier(string identifier);
    }
}