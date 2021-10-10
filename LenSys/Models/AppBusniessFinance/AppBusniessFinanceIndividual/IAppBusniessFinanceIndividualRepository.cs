using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual
{
    public interface IAppBusniessFinanceIndividualRepository
    {
        IEnumerable<AppBusniessFinanceIndividual> SetIndividualList(IEnumerable<AppBusniessFinanceIndividual> IndividualList);
        IEnumerable<AppBusniessFinanceIndividual> ClearIndividualList();
        AppBusniessFinanceIndividual GetIndividual(int IndividualId);
        IEnumerable<AppBusniessFinanceIndividual> GetAllIndividual();
        AppBusniessFinanceIndividual Add(AppBusniessFinanceIndividual individual);
        AppBusniessFinanceIndividual Update(AppBusniessFinanceIndividual individualchanges);
        AppBusniessFinanceIndividual Delete(int IndividualId);
    }
}
