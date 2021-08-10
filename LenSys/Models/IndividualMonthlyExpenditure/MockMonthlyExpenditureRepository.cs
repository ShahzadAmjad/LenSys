using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualMonthlyExpenditure
{
    public class MockMonthlyExpenditureRepository : IMonthlyExpenditureRepository
    {
        private List<MonthlyExpanditure> _monthlyExpanditure;
        public MockMonthlyExpenditureRepository()
        {

        }
        public MonthlyExpanditure Add(MonthlyExpanditure monthlyExpanditure)
        {
            throw new NotImplementedException();
        }
    }
}
