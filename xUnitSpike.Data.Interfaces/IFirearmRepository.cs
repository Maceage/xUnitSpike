using System.Linq;
using xUnitSpike.Data.Entities;

namespace xUnitSpike.Data.Interfaces
{
    public interface IFirearmRepository
    {
        IQueryable<Firearm> GetAll();

        Firearm GetByIdentifier(string identifier);
    }
}