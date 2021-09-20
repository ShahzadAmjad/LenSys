using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Busniess
{
    public interface IBusniessRepository
    {
        Busniess GetBusniess(int BusniessId);
        IEnumerable<Busniess> GetAllBusniess();
        Busniess Add(Busniess busniess);
        Busniess Update(Busniess busniessChanges);
        Busniess Delete(int BusniessId);
    }
}
