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
        AppAssetFinance Update(AppAssetFinance keyPrincipalsChanges);
        AppAssetFinance Delete(int KeyPrincipalsId);
    }
}
