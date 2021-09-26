using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess
{
    public interface IAppAssetFinanceBusniessRepository
    {
        IEnumerable<AppAssetFinanceBusniess> SetBusniessList(IEnumerable<AppAssetFinanceBusniess> BusniessList);
        AppAssetFinanceBusniess GetBusniess(int BusniessId);
        IEnumerable<AppAssetFinanceBusniess> GetAllBusniess();
        AppAssetFinanceBusniess Add(AppAssetFinanceBusniess busniess);
        AppAssetFinanceBusniess Update(AppAssetFinanceBusniess busniessChanges);
        AppAssetFinanceBusniess Delete(int BusniessId);

        IEnumerable<AppAssetFinanceBusniess> ClearBusniessList();
    }
}
