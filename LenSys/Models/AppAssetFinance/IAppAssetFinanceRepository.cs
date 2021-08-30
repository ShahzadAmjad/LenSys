using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppAssetFinance
{
   public interface IAppAssetFinanceRepository
    {
        AppAssetFinance GetAppAssetFinance(int KeyPrincipalsId);
        IEnumerable<AppAssetFinance> GetAllAppAssetFinance();
        AppAssetFinance Add(AppAssetFinance keyPrincipals);
        AppAssetFinance Update(AppAssetFinance keyPrincipalsChanges);
        AppAssetFinance Delete(int KeyPrincipalsId);
    }
}
