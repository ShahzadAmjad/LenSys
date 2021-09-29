using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessServiceability
{
   public interface IServiceabilityRepository
    {
        Serviceability Add(Serviceability serviceability);
        IEnumerable<Serviceability> ClearServiceabilityList();
        IEnumerable<Serviceability> SetServiceabilityList(IEnumerable<Serviceability> BusniessServiceabilityList);
        Serviceability GetServiceability(int serviceabilityId);
        IEnumerable<Serviceability> GetAllServiceability();
        Serviceability Update(Serviceability serviceability);
        Serviceability Delete(int id);
    }
}
