using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualIncomeExpenditure
{
    public class MockMonthlyIncomeRepository : IMonthlyIncomeRepository
    {
        private List<MonthlyIncome> _incomeExpenditures;
        public MockMonthlyIncomeRepository()
        {

        }
        public MonthlyIncome Add(MonthlyIncome incomeExpenditure)
        {
            throw new NotImplementedException();
        }
    }
}
