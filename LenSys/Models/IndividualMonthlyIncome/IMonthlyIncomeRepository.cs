using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualIncomeExpenditure
{
    interface IMonthlyIncomeRepository
    {
        MonthlyIncome Add(MonthlyIncome incomeExpenditure);
    }
}
