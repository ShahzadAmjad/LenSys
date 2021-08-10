using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualMonthlyExpenditure
{
    public class MockMonthlyExpenditureRepository : IMonthlyExpenditureRepository
    {
        private List<MonthlyExpenditure> _monthlyExpanditure;
        public MockMonthlyExpenditureRepository()
        {

        }
        public MonthlyExpenditure Add(MonthlyExpenditure monthlyExpanditure)
        {
            throw new NotImplementedException();
        }
    }
}
