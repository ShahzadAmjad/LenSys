using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualPersonalDetails
{
    interface IPersonalDetailsRepository
    {
        PersonalDetails Add(PersonalDetails personalDetails);
    }
}
