using xUnitSpike.Domain;

namespace xUnitSpike.Services.Interfaces
{
    public interface IFirearmService
    {
        Firearm GetByIdentifier(string identifier);
    }
}
