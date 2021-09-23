using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual
{
    public interface IAppAssetFinanceIndividualRepository
    {
        AppAssetFinanceIndividual GetIndividual(int IndividualId);
        IEnumerable<AppAssetFinanceIndividual> GetAllIndividual();
        AppAssetFinanceIndividual Add(AppAssetFinanceIndividual individual);
        AppAssetFinanceIndividual Update(AppAssetFinanceIndividual individualchanges);
        AppAssetFinanceIndividual Delete(int IndividualId);

        IEnumerable<AppAssetFinanceIndividual> ClearIndividualList();
    }
}
