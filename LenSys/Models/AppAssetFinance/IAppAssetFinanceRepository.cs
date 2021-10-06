using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppAssetFinance
{
   public interface IAppAssetFinanceRepository
    {
        
        AppAssetFinance GetAppAssetFinance(int KeyPrincipalsId);
        AppAssetFinance GetAppAssetFinance_EditHome(int KeyPrincipalsId);
        AppAssetFinance GetAppAssetFinance_appAssetFinance(int KeyPrincipalsId);
        IEnumerable<AppAssetFinance> GetAllAppAssetFinance();
        AppAssetFinance Add(AppAssetFinance keyPrincipals);
        //ForDirectly Insert to dB(Currently not in Use)
        AppAssetFinance AddIndividual(AppAssetFinanceIndividual.AppAssetFinanceIndividual individual);
        AppAssetFinance AddBusniess(AppAssetFinanceBusniess.AppAssetFinanceBusniess busniess);
        //End
        AppAssetFinance Update(AppAssetFinance keyPrincipalsChanges);
        AppAssetFinance Delete(int KeyPrincipalsId);
    }
}
