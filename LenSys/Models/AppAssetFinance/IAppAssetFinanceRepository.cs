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
        IEnumerable<AppAssetFinance> GetAllAppAssetFinance();
        //IEnumerable<AppAssetFinance> GetAllAppAssetFinance_AllApplicationPage();
        AppAssetFinance Add(AppAssetFinance keyPrincipals);
        AppAssetFinance AddIndividual(AppAssetFinanceIndividual.AppAssetFinanceIndividual individual);
        AppAssetFinance AddBusniess(AppAssetFinanceBusniess.AppAssetFinanceBusniess busniess);
        AppAssetFinance Update(AppAssetFinance keyPrincipalsChanges);
        AppAssetFinance Delete(int KeyPrincipalsId);
    }
}
