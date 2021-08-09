using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessServiceability
{
    public class MockServicebilityRepository : IServiceabilityRepository
    {
        private List<Serviceability> _serviceability;
        public MockServicebilityRepository()
        {

        }
        public Serviceability Add(Serviceability serviceability)
        {
            throw new NotImplementedException();
        }
    }
}
