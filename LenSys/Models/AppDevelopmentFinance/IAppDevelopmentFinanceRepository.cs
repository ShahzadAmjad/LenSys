using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance
{
    public interface IAppDevelopmentFinanceRepository
    {
        AppDevelopmentFinance GetAppDevelopmentFinance(int id);
        IEnumerable<AppDevelopmentFinance> GetAllAppDevelopmentFinance();
        AppDevelopmentFinance Add(AppDevelopmentFinance appDevelopmentFinance);
        AppDevelopmentFinance Update(AppDevelopmentFinance appDevelopmentFinanceChanges);
        AppDevelopmentFinance Delete(int id);
    }
}
