using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualPropertySchedule
{
    public interface IPropertyScheduleRepository
    {
        
        PropertySchedule Add(PropertySchedule propertySchedule);
        PropertySchedule GetPropertySchedule(int propertyId);
        IEnumerable<PropertySchedule> GetAllPropertySchedule();
        PropertySchedule Update(PropertySchedule propertyScheduleChanges);
        PropertySchedule Delete(int id);
    }
}
