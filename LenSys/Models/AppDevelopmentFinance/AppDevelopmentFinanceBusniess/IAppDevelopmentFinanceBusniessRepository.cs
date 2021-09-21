using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess
{
    public interface IAppDevelopmentFinanceBusniessRepository
    {
        AppDevelopmentFinanceBusniess GetBusniess(int BusniessId);
        IEnumerable<AppDevelopmentFinanceBusniess> GetAllBusniess();
        AppDevelopmentFinanceBusniess Add(AppDevelopmentFinanceBusniess busniess);
        AppDevelopmentFinanceBusniess Update(AppDevelopmentFinanceBusniess busniessChanges);
        AppDevelopmentFinanceBusniess Delete(int BusniessId);
    }
}
