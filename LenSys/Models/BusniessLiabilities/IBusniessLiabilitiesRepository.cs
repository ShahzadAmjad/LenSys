using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessLiabilities
{
   public interface IBusniessLiabilitiesRepository
    {
        BusniessLiabilities Add(BusniessLiabilities busniessLiabilities);
        BusniessLiabilities GetBusniessLiabilities(int BusniessLiabilityId);
        IEnumerable<BusniessLiabilities> GetAllBusniessLiabilities();
        BusniessLiabilities Update(BusniessLiabilities BusniessLiabilitiesChanges);
        BusniessLiabilities Delete(int id);
    }
}
