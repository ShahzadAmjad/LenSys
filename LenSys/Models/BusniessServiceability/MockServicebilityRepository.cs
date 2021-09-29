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
            _serviceability = new List<Serviceability>()
            {
                new Serviceability{ServiceabilityId=1, Year=(DateTime.Now.Year).ToString(),TurnOver=2000, NetProfit=1000,EBITDA="50000"},
                new Serviceability{ServiceabilityId=2, Year=(DateTime.Now.Year).ToString(),TurnOver=3000, NetProfit=2000,EBITDA="60000"},
                new Serviceability{ServiceabilityId=3, Year=(DateTime.Now.Year).ToString(),TurnOver=4000, NetProfit=3000,EBITDA="70000"}

            };
        }
        public Serviceability Add(Serviceability serviceability)
        {
            serviceability.ServiceabilityId = _serviceability.Max(e => e.ServiceabilityId) + 1;
            _serviceability.Add(serviceability);
            return serviceability;
        }

        public IEnumerable<Serviceability> ClearServiceabilityList()
        {
            _serviceability.Clear();
            return _serviceability;
        }

        public Serviceability Delete(int id)
        {
            Serviceability serviceability = _serviceability.FirstOrDefault(e => e.ServiceabilityId == id);
            if (serviceability != null)
            {
                _serviceability.Remove(serviceability);
            }
            return serviceability;
        }

        public IEnumerable<Serviceability> GetAllServiceability()
        {
            return _serviceability;
        }

        public Serviceability GetServiceability(int serviceabilityId)
        {
            return _serviceability.FirstOrDefault(e => e.ServiceabilityId == serviceabilityId);
        }

        public IEnumerable<Serviceability> SetServiceabilityList(IEnumerable<Serviceability> BusniessServiceabilityList)
        {
            _serviceability = (List<Serviceability>)BusniessServiceabilityList;

            return _serviceability;
        }

        public Serviceability Update(Serviceability model)
        {
            Serviceability serviceability = _serviceability.FirstOrDefault(e => e.ServiceabilityId == model.ServiceabilityId);
            if (serviceability != null)
            {
                //serviceability.ServiceabilityId = model.ServiceabilityId;
                serviceability.Year = model.Year;
                serviceability.TurnOver = model.TurnOver;
                serviceability.NetProfit = model.NetProfit;
                serviceability.EBITDA = model.EBITDA;               
            }
            return serviceability;
        }
    }
}
