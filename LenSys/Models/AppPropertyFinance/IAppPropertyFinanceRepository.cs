using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance
{
    public interface IAppPropertyFinanceRepository
    {
        AppPropertyFinance GetAppPropertyFinance(int id);
        IEnumerable<AppPropertyFinance> GetAllAppPropertyFinance();
        AppPropertyFinance Add(AppPropertyFinance appPropertyFinance);
        AppPropertyFinance Update(AppPropertyFinance appPropertyFinanceChanges);
        AppPropertyFinance Delete(int id);
    }
}
