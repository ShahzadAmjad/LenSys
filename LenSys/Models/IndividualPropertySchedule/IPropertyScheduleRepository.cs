using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualPropertySchedule
{
    public interface IPropertyScheduleRepository
    {
        
        PropertySchedule Add(PropertySchedule propertySchedule);
        IEnumerable<PropertySchedule> ClearPropertyScheduleList();
        PropertySchedule GetPropertySchedule(int propertyId);
        IEnumerable<PropertySchedule> GetAllPropertySchedule();
        IEnumerable<PropertySchedule> SetPropertyScheduleList(IEnumerable<PropertySchedule> PropertyScheduleList);
        PropertySchedule Update(PropertySchedule propertyScheduleChanges);
        PropertySchedule Delete(int id);
    }
}
