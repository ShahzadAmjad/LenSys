using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualPropertySchedule
{
    public class MockPropertyScheduleRepository : IPropertyScheduleRepository
    {
        private List<PropertySchedule> _propertySchedule;
        public MockPropertyScheduleRepository()
        {
                
        }
        public PropertySchedule Add(PropertySchedule propertySchedule)
        {
            throw new NotImplementedException();
        }
    }
}
