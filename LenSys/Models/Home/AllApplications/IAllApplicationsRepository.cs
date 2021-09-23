using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.AllApplications
{
    public interface IAllApplicationsRepository
    {
        AllApplications GetApplication(int Id);
        AppAssetFinance.AppAssetFinance GetAssetFinanceApplication(int Id);
        IEnumerable<AllApplications> GetAllApplications();
        IEnumerable<AppAssetFinance.AppAssetFinance> GetAllAssetFinanceApplication();
        AllApplications Add(AllApplications Applications);
        AllApplications Update(AllApplications ApplicationsChanges);
        AllApplications Delete(int ApplicationId);
        AppAssetFinance.AppAssetFinance DeleteAssetFinanceApplication(int ApplicationId);
    }
}
