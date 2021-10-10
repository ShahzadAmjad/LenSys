using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual
{
    public interface IAppPropertyFinanceIndividualRepository
    {
        IEnumerable<AppPropertyFinanceIndividual> SetIndividualList(IEnumerable<AppPropertyFinanceIndividual> IndividualList);
        IEnumerable<AppPropertyFinanceIndividual> ClearIndividualList();
        AppPropertyFinanceIndividual GetIndividual(int IndividualId);
        IEnumerable<AppPropertyFinanceIndividual> GetAllIndividual();
        AppPropertyFinanceIndividual Add(AppPropertyFinanceIndividual individual);
        AppPropertyFinanceIndividual Update(AppPropertyFinanceIndividual individualchanges);
        AppPropertyFinanceIndividual Delete(int IndividualId);
    }
}
