using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualIncomeExpenditure
{
    public class MockIncomeExpenditureRepository : IincomeExpenditureRepository
    {
        private List<IncomeExpenditure> _incomeExpenditures;
        public MockIncomeExpenditureRepository()
        {

        }
        public IncomeExpenditure Add(IncomeExpenditure incomeExpenditure)
        {
            throw new NotImplementedException();
        }
    }
}
