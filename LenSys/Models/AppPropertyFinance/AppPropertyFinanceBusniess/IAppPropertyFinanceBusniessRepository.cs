using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess
{
    public interface IAppPropertyFinanceBusniessRepository
    {
        IEnumerable<AppPropertyFinanceBusniess> SetBusniessList(IEnumerable<AppPropertyFinanceBusniess> BusniessList);
        AppPropertyFinanceBusniess GetBusniess(int BusniessId);
        IEnumerable<AppPropertyFinanceBusniess> GetAllBusniess();
        AppPropertyFinanceBusniess Add(AppPropertyFinanceBusniess busniess);
        AppPropertyFinanceBusniess Update(AppPropertyFinanceBusniess busniessChanges);
        AppPropertyFinanceBusniess Delete(int BusniessId);
        IEnumerable<AppPropertyFinanceBusniess> ClearBusniessList();
    }
}
