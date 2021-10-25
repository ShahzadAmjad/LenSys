using LenSys.Models.Home.AllApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance
{
    public interface IAppDevelopmentFinanceRepository
    {
        AppDevelopmentFinance GetAppDevelopmentFinance(int id);
        AppDevelopmentFinance GetAppDevelopmentFinance_EditHome(int id);
        AppDevelopmentFinance GetAppDevelopmentFinance_appDevelopmentFinance(int id);
        IEnumerable<AllApplications> GetAllAppDevelopmentFinance_AllApplication();
        IEnumerable<AllApplications> SearchAppDevelopmentFinance(string SearchAttribute, string SearchParam);
        IEnumerable<AppDevelopmentFinance> GetAllAppDevelopmentFinance();
        AppDevelopmentFinance Add(AppDevelopmentFinance appDevelopmentFinance);
        //ForDirectly Insert to dB(Currently not in Use)
        AppDevelopmentFinance AddIndividual(AppDevelopmentFinanceIndividual.AppDevelopmentFinanceIndividual individual);
        AppDevelopmentFinance AddBusniess(AppDevelopmentFinanceBusniess.AppDevelopmentFinanceBusniess busniess);
        //End
        AppDevelopmentFinance Update(AppDevelopmentFinance appDevelopmentFinanceChanges);
        AppDevelopmentFinance Delete(int id);
    }
}
