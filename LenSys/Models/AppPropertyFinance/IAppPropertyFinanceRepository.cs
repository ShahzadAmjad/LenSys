using LenSys.Models.Home.AllApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance
{
    public interface IAppPropertyFinanceRepository
    {
        AppPropertyFinance GetAppPropertyFinance(int id);
        AppPropertyFinance GetAppPropertyFinance_EditHome(int id);
        AppPropertyFinance GetAppPropertyFinance_appPropertyFinance(int id);
        IEnumerable<AllApplications> GetAllAppPropertyFinance_AllApplication();
        IEnumerable<AllApplications> SearchAppPropertyFinance(string SearchAttribute, string SearchParam);
        IEnumerable<AppPropertyFinance> GetAllAppPropertyFinance();
        AppPropertyFinance Add(AppPropertyFinance appPropertyFinance);
        //ForDirectly Insert to dB(Currently not in Use)
        AppPropertyFinance AddIndividual(AppPropertyFinanceIndividual.AppPropertyFinanceIndividual individual);
        AppPropertyFinance AddBusniess(AppPropertyFinanceBusniess.AppPropertyFinanceBusniess busniess);
        //End
        AppPropertyFinance Update(AppPropertyFinance appPropertyFinanceChanges);
        AppPropertyFinance Delete(int id);
    }
}
