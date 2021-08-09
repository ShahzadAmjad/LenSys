using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessDetails
{
    public class MockBusniessDetailsRepository : IBusniessDetailsRepository
    {
        private List<BusniessDetails> _busniessDetails;
        public MockBusniessDetailsRepository()
        {

        }
        public BusniessDetails Add(BusniessDetails busniessDetails)
        {
            throw new NotImplementedException();
        }
    }
}
