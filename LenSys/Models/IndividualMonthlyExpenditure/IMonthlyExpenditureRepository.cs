using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualMonthlyExpenditure
{
    interface IMonthlyExpenditureRepository
    {
        MonthlyExpenditure Add(MonthlyExpenditure monthlyExpanditure);
    }
}
