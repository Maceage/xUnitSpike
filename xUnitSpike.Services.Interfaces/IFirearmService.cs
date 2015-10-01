using System.Collections.Generic;
using xUnitSpike.Domain;

namespace xUnitSpike.Services.Interfaces
{
    public interface IFirearmService
    {
        IEnumerable<Firearm> GetAll();
        Firearm GetByIdentifier(string identifier);

        string Save(Firearm firearm);

        bool Delete(Firearm firearm);
    }
}
