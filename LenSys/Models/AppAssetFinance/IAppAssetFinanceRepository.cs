using LenSys.Models.Home.AllApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppAssetFinance
{
   public interface IAppAssetFinanceRepository
    {
        
        AppAssetFinance GetAppAssetFinance(int id);
        AppAssetFinance GetAppAssetFinance_EditHome(int id);
        AppAssetFinance GetAppAssetFinance_appAssetFinance(int id);
        IEnumerable<AllApplications> GetAllAppAssetFinance_AllApplication();
        IEnumerable<AppAssetFinance> GetAllAppAssetFinance();
        
        AppAssetFinance Add(AppAssetFinance appAssetFinance);
        //ForDirectly Insert to dB(Currently not in Use)
        AppAssetFinance AddIndividual(AppAssetFinanceIndividual.AppAssetFinanceIndividual individual);
        AppAssetFinance AddBusniess(AppAssetFinanceBusniess.AppAssetFinanceBusniess busniess);
        //End
        AppAssetFinance Update(AppAssetFinance keyPrincipalsChanges);
        AppAssetFinance Delete(int KeyPrincipalsId);
    }
}
