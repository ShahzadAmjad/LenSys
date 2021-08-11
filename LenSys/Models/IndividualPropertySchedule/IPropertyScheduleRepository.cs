using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualPropertySchedule
{
    public interface IPropertyScheduleRepository
    {
        PropertySchedule GetPropertySchedule(int propertyId);
        IEnumerable<PropertySchedule> GetAllPropertySchedule();
        //Old One
        PropertySchedule Add(PropertySchedule propertySchedule);
        PropertySchedule Update(PropertySchedule propertyScheduleChanges);
        PropertySchedule Delete(int id);
    }
}
