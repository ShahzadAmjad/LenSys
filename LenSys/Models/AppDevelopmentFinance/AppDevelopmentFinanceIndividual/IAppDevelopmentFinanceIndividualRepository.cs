using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual
{
    public interface IAppDevelopmentFinanceIndividualRepository
    {
        AppDevelopmentFinanceIndividual GetIndividual(int IndividualId);
        IEnumerable<AppDevelopmentFinanceIndividual> GetAllIndividual();
        AppDevelopmentFinanceIndividual Add(AppDevelopmentFinanceIndividual individual);
        AppDevelopmentFinanceIndividual Update(AppDevelopmentFinanceIndividual individualchanges);
        AppDevelopmentFinanceIndividual Delete(int IndividualId);
    }
}
