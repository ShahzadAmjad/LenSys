using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessLiabilities
{
    interface IBusniessLiabilitiesRepository
    {
        BusniessLiabilities Add(BusniessLiabilities busniessLiabilities);
    }
}
