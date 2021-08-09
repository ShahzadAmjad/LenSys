using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualCreditHistory
{
    public class MockCreditHistoryRepository : ICreditHistoryRepository
    {
        private List<CreditHistory> _creditHistory;
        public MockCreditHistoryRepository()
        {
                
        }

        public CreditHistory Add(CreditHistory creditHistory)
        {
            throw new NotImplementedException();
        }
    }
}
