using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance
{
    public interface IAppPropertyFinanceSecurityDetailsRepository
    {
        IEnumerable<AppPropertyFinanceSecurityDetails> SetSecurityDetailsList(IEnumerable<AppPropertyFinanceSecurityDetails> IndividualList);
        IEnumerable<AppPropertyFinanceSecurityDetails> ClearSecurityDetailsList();
        AppPropertyFinanceSecurityDetails GetAppPropertysFinanceSecurityDetails(int AppPropertyFinanceSecurityDetailsId);
        IEnumerable<AppPropertyFinanceSecurityDetails> GetAllAppPropertyFinanceSecurityDetails();
        AppPropertyFinanceSecurityDetails Add(AppPropertyFinanceSecurityDetails appPropertyFinanceSecurityDetails);
        AppPropertyFinanceSecurityDetails Update(AppPropertyFinanceSecurityDetails appPropertyFinanceSecurityDetailsChanges);
        AppPropertyFinanceSecurityDetails Delete(int AppPropertyFinanceSecurityDetailsId);
    }
}
