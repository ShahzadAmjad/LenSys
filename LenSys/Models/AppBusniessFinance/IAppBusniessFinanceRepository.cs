using LenSys.Models.Home.AllApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance
{
    public interface IAppBusniessFinanceRepository
    {
        AppBusniessFinance GetAppBusniessFinance(int id);
        AppBusniessFinance GetAppBusniessFinance_EditHome(int id);
        //AppBusniessFinance GetAppBusniessFinance_CURDBusIndSec(int id);
        AppBusniessFinance GetAppBusniessFinance_appBusniessFinance(int id);
        IEnumerable<AppBusniessFinance> GetAllAppBusniessFinance();
        IEnumerable<AllApplications> GetAllAppBusniessFinance_AllApplication();
        IEnumerable<AllApplications> SearchAppBusniessFinance(string SearchAttribute, string SearchParam);
        AppBusniessFinance Add(AppBusniessFinance appBusniessFinance);
        //ForDirectly Insert to dB(Currently not in Use)
        AppBusniessFinance AddIndividual(AppBusniessFinanceIndividual.AppBusniessFinanceIndividual individual);
        AppBusniessFinance AddBusniess(AppBusniessFinanceBusniess.AppBusniessFinanceBusniess busniess);
        //End
        AppBusniessFinance Update(AppBusniessFinance appBusniessFinanceChanges);
        AppBusniessFinance Delete(int id);
    }
}
