using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance
{
    public interface IAppDevelopmentFinanceSecurityDetailsRepository
    {
        AppDevelopmentFinanceSecurityDetails GetAppDevelopmentFinanceSecurityDetails(int AppDevelopmentFinanceSecurityDetailsId);
        IEnumerable<AppDevelopmentFinanceSecurityDetails> GetAllAppDevelopmentFinanceSecurityDetails();
        AppDevelopmentFinanceSecurityDetails Add(AppDevelopmentFinanceSecurityDetails appDevelopmentFinanceSecurityDetails);
        AppDevelopmentFinanceSecurityDetails Update(AppDevelopmentFinanceSecurityDetails appDevelopmentFinanceSecurityDetailsChanges);
        AppDevelopmentFinanceSecurityDetails Delete(int AppDevelopmentFinanceSecurityDetailsId);
    }
}
