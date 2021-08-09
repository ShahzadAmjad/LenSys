using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessDetails
{
    interface IBusniessDetailsRepository
    {
        BusniessDetails Add(BusniessDetails busniessDetails);
    }
}
