using System.Linq;
using xUnitSpike.Data.Entities;

namespace xUnitSpike.Data.Interfaces
{
    public interface IFirearmRepository
    {
        IQueryable<FirearmEntity> GetAll();
        FirearmEntity GetByIdentifier(string identifier);

        FirearmEntity Save(FirearmEntity firearmEntity);

        bool Delete(FirearmEntity firearmEntity);
    }
}