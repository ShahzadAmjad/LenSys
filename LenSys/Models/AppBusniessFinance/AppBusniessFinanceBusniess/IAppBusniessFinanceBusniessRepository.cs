using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess
{
    public interface IAppBusniessFinanceBusniessRepository
    {
        AppBusniessFinanceBusniess GetBusniess(int BusniessId);
        IEnumerable<AppBusniessFinanceBusniess> GetAllBusniess();
        AppBusniessFinanceBusniess Add(AppBusniessFinanceBusniess busniess);
        AppBusniessFinanceBusniess Update(AppBusniessFinanceBusniess busniessChanges);
        AppBusniessFinanceBusniess Delete(int BusniessId);
    }
}
