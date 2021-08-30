using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance
{
    public interface IAppBusniessFinanceRepository
    {
        AppBusniessFinance GetAppBusniessFinance(int id);
        IEnumerable<AppBusniessFinance> GetAllAppBusniessFinance();
        AppBusniessFinance Add(AppBusniessFinance appBusniessFinance);
        AppBusniessFinance Update(AppBusniessFinance appBusniessFinanceChanges);
        AppBusniessFinance Delete(int id);
    }
}
