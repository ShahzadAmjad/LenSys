using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance
{
    public interface IAppBusniessFinanceSecurityDetailsRepository
    {
        IEnumerable<AppBusniessFinanceSecurityDetails> SetIndividualList(IEnumerable<AppBusniessFinanceSecurityDetails> IndividualList);
        IEnumerable<AppBusniessFinanceSecurityDetails> ClearIndividualList();
        AppBusniessFinanceSecurityDetails GetAppBusniessFinanceSecurityDetails(int AppBusniessFinanceSecurityDetailsId);
        IEnumerable<AppBusniessFinanceSecurityDetails> GetAllAppBusniessFinanceSecurityDetails();
        AppBusniessFinanceSecurityDetails Add(AppBusniessFinanceSecurityDetails appBusniessFinanceSecurityDetails);
        AppBusniessFinanceSecurityDetails Update(AppBusniessFinanceSecurityDetails appBusniessFinanceSecurityDetailsChanges);
        AppBusniessFinanceSecurityDetails Delete(int AppBusniessFinanceSecurityDetailsId);
    }
}
