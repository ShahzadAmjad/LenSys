using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessLiabilities
{
    public class MockBusniessLiabilitiesRepository : IBusniessLiabilitiesRepository
    {
        private List<BusniessLiabilities> _busniessLiabilities;
        public MockBusniessLiabilitiesRepository()
        {

        }
        public BusniessLiabilities Add(BusniessLiabilities busniessLiabilities)
        {
            throw new NotImplementedException();
        }
    }
}
