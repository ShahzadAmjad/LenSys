using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessServiceability
{
    interface IServiceabilityRepository
    {
        Serviceability Add(Serviceability serviceability);
    }
}
