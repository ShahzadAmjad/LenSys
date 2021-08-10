using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualLiabilities
{
    public class MockLiabilitiesRepository : ILiabilitiesRepository
    {
        private List<Liabilities> _liabilities;
        public MockLiabilitiesRepository()
        {
                
        }
        public Liabilities Add(Liabilities liabilities)
        {
            throw new NotImplementedException();
        }
    }
}
